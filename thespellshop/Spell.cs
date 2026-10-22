using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace thespellshop
{
    internal class Spell
    {

        //properties

        private string requiredIngredients { get; set; }

        public string Name { get; set; }

        public int energycost { get; private set; }

        public bool Isrequested { get; set; }

        //Constructor

        public Spell(string name, int energycost, string requiredIngredients)
        {
            Name = name;
            this.energycost = energycost;
            this.requiredIngredients = requiredIngredients;
            Isrequested = false;
        }

        //Methods

        public string Request()
        {
            Isrequested = true;
            return $"Spell {Name} has been requested.";
        }

        public string Cast(ingredient ingredient)
        {
            if (!Isrequested)
            {
                return $"Nobody asked for {Name}";
            }
            if(ingredient.Name.ToLower() == requiredIngredients.ToLower())
            {
                Isrequested = false;
                return $"Spell {Name} has been cast successfully using {ingredient.Name}.";
            }

            return $"The {ingredient.Name} does nothing useful. {Name} fizzzles";
        }

        public override string ToString()
        {
            string state = "-";
            if(Isrequested)
            {
                state = "Wanted";
            }
            return $"{Name,-16}{state,-8} {energycost} energy ";
        }
    }
}
