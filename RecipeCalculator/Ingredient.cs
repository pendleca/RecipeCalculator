using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator
{
    class Ingredient
    {
        //Private members
        private string name;
        private double cost;
        private double amount;
        private bool isOrganic;
        private bool isProduce;

        //Public members
        public string Name {
            get { return name;}
            set { name = value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public bool IsOrganic
        {
            get { return isOrganic; }
            set { isOrganic = value; }
        }
        public bool IsProduce
        {
            get { return isProduce; }
            set { isProduce = value; }
        }

    }
}
