using FactoryCodingChallenge.Factory;
using FactoryCodingChallenge.Logger;
using FactoryCodingChallenge.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryCodingChallenge.Test.Factory
{
    public class AutoFactoryTest : TestCaseTemplate
    {
        IInventory Inventory;

        IRecipe Recipe;

        Mock<ILogger> Logger;

        IAutoFactory Factory;

        [SetUp]
        public void SetUp()
        {
            Inventory = new Inventory(InventoryJSON);
            Recipe = new Recipe(RecipesJSON);
            Logger = new Mock<ILogger>();
            Factory = new AutoFactory(Inventory, Recipe, Logger.Object);
        }
        
        [Test]
        public void TestBuild()
        {
            var part = Recipe.GetRecipe("recipe_gear");
            Factory.Build("recipe_gear", 1);
            Logger.Verify(o => o.Log(0, part, part.Time, "\t"), Times.Once);
            
            var stocks = Factory.Inventory.Stocks["iron_gear"];
            Assert.AreEqual(stocks, 6);
        }
    }
}
