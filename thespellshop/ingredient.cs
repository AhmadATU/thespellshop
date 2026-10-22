using System;
using System.Collections.Generic;
using System.Text;

namespace thespellshop
{
    internal class ingredient
    {
        //properties

        public string Name { get; private set; }

        public int Description { get; set; }
        //constructor

        public ingredient(string name, int description)
        {
            Name = name;
            Description = description;
        }   

        //methods

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}";
        }

    }
}
