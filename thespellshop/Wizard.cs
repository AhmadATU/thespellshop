using System;
using System.Collections.Generic;
using System.Text;

namespace thespellshop
{
    internal class Wizard
    {

        //properties

        private List<ingredient> satchel = new List<ingredient>();
        

        public string Name { get; private set; }

        public int Maxingredient { get; private set; }

        public int IngredientCount 
        {
            get
            {
                return satchel.Count;   
            }
        }

        private int energy = 0;

        public int Energy
        {
            get
            { return energy;}
            set
            {
                if(value < 0)
                {
                    energy = 0;
                }
                else if (value > 100)
                {
                    energy = 100;
                }
                else
                {
                    energy = value;
                }
            }
        }
        //constructer

        public Wizard(string name, int maxingredient, int energy)
        {
            Name = name;
            Maxingredient = maxingredient;
            Energy = energy;
        }

        //method

        public bool Pickup(ingredient ingredient)
        {
            if (satchel.Count >= Maxingredient)
            {
                return false;
            }
            satchel.Add(ingredient);

            return true;
        }

        //return the ingredient if it is found, otherwise return null

        public ingredient FindIngredient(string ingredientName)
        {
            foreach (ingredient ingredient in satchel)
            {
              if(ingredient.Name.ToLower() == ingredientName.ToLower())
              {
                    return ingredient;
              }
            }
            return null;
        }

        //private only the wizard spends energy
        //retrurn false if the wizard does not have enough energy to spend, otherwise return true

        private bool SpendEnergy(int amount)
        {
            if (Energy > amount)
            {
                return false;
            }
            Energy -= amount;
            return true;
        }

        //The wizards cast spell, it cost energy

        public string Cast(Spell spell, ingredient ingredient)
        {
            if(!spell.Isrequested)
            {
                return $"Nobody asked for {spell.Name}!";
            }

            if(!SpendEnergy(spell.energycost))
            {
                return $"Not enough energy to cast {spell.Name} it requires spell. it requires {spell.energycost}";

            }
            return spell.Cast(ingredient);
        }

        //remove an ingredient 

        public ingredient Drop(string ingredientName)
        {
            ingredient ingredient = FindIngredient(ingredientName);
            if (ingredient != null)
            {
                satchel.Remove(ingredient);
                
            }
            return ingredient;
        }

        public void Rest(int amount)
        {
            Energy += amount;
        }

        public void ShowSatchel()
        {
            Console.WriteLine($"Satchel of {Name}");
            Console.WriteLine($"{"Name",-16} {"Description",-8}");
            foreach (ingredient ingredient in satchel)
            {
                Console.WriteLine($"{ingredient.Name,-16} {ingredient.Description,-8}");
            }
        }


    }
}
