using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator
{
    public class Recipe
    {
        //Initialize constants
        private const double GARLIC = .67;
        private const double LEMON = 2.03;
        private const double CORN = .87;
        private const double CHICKEN = 2.19;
        private const double BACON = .24;
        private const double PASTA = .31;
        private const double OLIVEOIL = 1.92;
        private const double VINEGAR = 1.26;
        private const double SALT = .16;
        private const double PEPPER = .17;
        private const double SALESTAX = .086;
        private const double WELLNESSDISCOUNT = .05;

        private double salesTax; //Sales tax for this recipe
        private double total; //Total for this recipe
        private double wellnessDiscount; //Wellness Discount for this recipe
        private List<Ingredient> Ingredients; //List of ingrediants for this recipe
        private Dictionary<string, double> IngredientCostDict; //Dictionary pairing name and price of item

        //Public members
        public double Garlic {
            set { AddIngredient("Garlic", value); }
        }
        public double Lemon {
            set { AddIngredient("Lemon", value); }
        }
        public double Corn {
            set { AddIngredient("Corn", value); }
        }
        public double Chicken {
            set { AddIngredient("Chicken", value); }
        }
        public double Bacon {
            set { AddIngredient("Bacon", value); }
        }
        public double Pasta {
            set { AddIngredient("Pasta", value); }
        }
        public double OliveOil {
            set { AddIngredient("Olive Oil", value); }
        }
        public double Vinegar {
            set { AddIngredient("Vinegar", value); }
        }
        public double Salt {
            set { AddIngredient("Salt", value); }
        }
        public double Pepper {
            set { AddIngredient("Pepper", value); }
        }     

        //Constructor
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            IngredientCostDict = new Dictionary<string, double>();
        }

        //Returns the Sales Tax for this recipe
        public double getTax()
        {
            if(salesTax == 0)
            {
                calculateRecipe();
            }

            return salesTax;
        }

        //Returns the Wellness Discount for this recipe
        public double getDiscount()
        {
            if (wellnessDiscount == 0)
            {
                calculateRecipe();
            }

            return wellnessDiscount;
        }

        //Returns the Total for this recipe
        public double getTotal()
        {
            if (total == 0)
            {
                calculateRecipe();
            }

            return total;
        }

        //Calculates sets the global variables of sales tax, wellness discount, and total for this recipe 
        public void calculateRecipe()
        {
            double applyTaxTotal = 0; //amount to apply sales tax
            double noTaxTotal = 0; //amount to not apply sales tax
            double discountTotal = 0; //amount to apply discount

            //Iterate through list of Ingredients for this recipe
            foreach(Ingredient ingredient in Ingredients)
            {
                if (ingredient.IsProduce) //Is a produce item
                {
                    //add price of ingredient to total for not applying tax
                    noTaxTotal = noTaxTotal + (ingredient.Amount * ingredient.Cost);
                }
                else //Is not a produce item
                {
                    //add price of ingredient to total for applying tax
                    applyTaxTotal = applyTaxTotal + (ingredient.Amount * ingredient.Cost);
                }

                if (ingredient.IsOrganic)//Is an organic item
                {
                    //add price of ingredient to total for applying discount
                    discountTotal = discountTotal + (ingredient.Amount * ingredient.Cost);
                }
            }

            //Find sales tax to nearest 7 cent
            double ceiling = Math.Ceiling(applyTaxTotal * SALESTAX * 100) / 7;

            //Check if ceiling is a whole number
            if (ceiling % 1 != 0) //not a whole number
            {
                salesTax = Math.Ceiling(ceiling) * 7 / 100;
            }
            else //ceiling is a whole number
            {
                salesTax = ceiling * 7 / 100;
            }

            //Calculate wellness discount
            wellnessDiscount = Math.Ceiling(discountTotal * WELLNESSDISCOUNT * 100) / 100;

            //Calculate total
            total = Math.Ceiling((salesTax + noTaxTotal + applyTaxTotal - wellnessDiscount) * 100) / 100;   
        }

        //Adds Ingredient to list of ingredients or changes value of current ingredient in list
        private void AddIngredient(string name, double amount)
        {
            //Initialize dictionary
            if (IngredientCostDict.Keys.Count == 0)
            {
                initializeDictionary();
            }

            var ing = Ingredients.Where(i => i.Name == name);
            
            if (ing.ToList().Count == 0)//Ingredient is not in the list
            {
                //Check if item is organic
                bool isOrganic = false;
                if(name == "Garlic" || name == "Olive Oil")
                {
                    isOrganic = true;
                }
                //Check if item is produce
                bool isProduce = false;
                if (name == "Garlic" || name == "Lemon" || name =="Corn")
                {
                    isProduce = true;
                }
                //Create ingredient
                Ingredient ingredient = new Ingredient { Amount = amount, Name = name, Cost = IngredientCostDict[name], IsOrganic=isOrganic, IsProduce=isProduce };

                //Add ingredient to the list
                Ingredients.Add(ingredient);
            }
            else //Ingredient is in the list
            {
                //Change value of current ingredient in list and recalculate recipe
                Ingredient ingredient = ing.Single();
                ingredient.Amount = amount;
                calculateRecipe();
            }
            
        }

        //Initializes the item to price of item dictionary
        private void initializeDictionary()
        {          
                IngredientCostDict.Add("Garlic", GARLIC);
                IngredientCostDict.Add("Lemon", LEMON);
                IngredientCostDict.Add("Corn", CORN);
                IngredientCostDict.Add("Chicken", CHICKEN);
                IngredientCostDict.Add("Bacon", BACON);
                IngredientCostDict.Add("Pasta", PASTA);
                IngredientCostDict.Add("Olive Oil", OLIVEOIL);
                IngredientCostDict.Add("Vinegar", VINEGAR);
                IngredientCostDict.Add("Salt", SALT);
                IngredientCostDict.Add("Pepper", PEPPER);
        }

    }
}
