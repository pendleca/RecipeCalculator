using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeCalculator;

namespace RecipeCalculatorTest
{
    [TestClass]
    public class RecipeTest
    {
        Recipe recipeOne = new Recipe {Garlic = 1, OliveOil = .75, Lemon = 1, Salt = .75, Pepper = .5};
        Recipe recipeTwo = new Recipe { Garlic = 1, Chicken = 4, OliveOil = .5, Vinegar = .5 };
        Recipe recipeThree = new Recipe {Garlic = 1, Corn = 4, Bacon = 4, Pasta = 8, OliveOil = .33, Salt = 1.25, Pepper = .75};

        [TestMethod]
        public void RecipeOneSalesTaxTest()
        {
            double tax = recipeOne.getTax();
            double expected = .21;
            Assert.AreEqual(expected, tax);
        }

        [TestMethod]
        public void RecipeOneDiscountTest()
        {
            double discount = recipeOne.getDiscount();
            double expected = .11;
            Assert.AreEqual(expected, discount);
        }

        [TestMethod]
        public void RecipeOneTotalTest()
        {
            double total = recipeOne.getTotal();
            double expected = 4.45;
            Assert.AreEqual(expected, total);
        }

        [TestMethod]
        public void RecipeTwoSalesTaxTest()
        {
            double tax = recipeTwo.getTax();
            double expected = .91;
            Assert.AreEqual(expected, tax);
        }

        [TestMethod]
        public void RecipeTwoDiscountTest()
        {
            double discount = recipeTwo.getDiscount();
            double expected = .09;
            Assert.AreEqual(expected, discount);
        }

        [TestMethod]
        public void RecipeTwoTotalTest()
        {
            double total = recipeTwo.getTotal();
            double expected = 11.84;
            Assert.AreEqual(expected, total);
        }
        [TestMethod]
        public void RecipeThreeSalesTaxTest()
        {
            double tax = recipeThree.getTax();
            double expected = .42;
            Assert.AreEqual(expected, tax);
        }

        [TestMethod]
        public void RecipeThreeDiscountTest()
        {
            double discount = recipeThree.getDiscount();
            double expected = .07;
            Assert.AreEqual(expected, discount);
        }

        [TestMethod]
        public void RecipeThreeTotalTest()
        {
            double total = recipeThree.getTotal();
            double expected = 8.91;
            Assert.AreEqual(expected, total);
        }
    }
}
