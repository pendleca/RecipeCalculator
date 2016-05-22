using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe1 = new Recipe
            {
                Garlic = 1,
                OliveOil = .75,
                Lemon = 1,
                Salt = .75,
                Pepper = .5
            };
            //Print data for recipe 1
            Console.WriteLine("Recipe 1");
            Console.WriteLine("Tax: " + recipe1.getTax());
            Console.WriteLine("Discount: " + recipe1.getDiscount());
            Console.WriteLine("Total: " + recipe1.getTotal() + "\n");

            Recipe recipe2 = new Recipe
            {
                Garlic = 1,
                Chicken = 4,
                OliveOil = .5,
                Vinegar = .5
            };
            //Print data for recipe 2
            Console.WriteLine("Recipe 2");
            Console.WriteLine("Tax: " + recipe2.getTax());
            Console.WriteLine("Discount: " + recipe2.getDiscount());
            Console.WriteLine("Total: " + recipe2.getTotal() + "\n");

            Recipe recipe3 = new Recipe
            {
                Garlic = 1,
                Corn = 4,
                Bacon = 4,
                Pasta = 8,
                OliveOil = .33,
                Salt = 1.25,
                Pepper = .75
            };
            //Print data for recipe 3
            Console.WriteLine("Recipe 3");
            Console.WriteLine("Tax: " + recipe3.getTax());
            Console.WriteLine("Discount: " + recipe3.getDiscount());
            Console.WriteLine("Total: " + recipe3.getTotal() + "\n");

            Console.ReadLine();
        }
    }
}
