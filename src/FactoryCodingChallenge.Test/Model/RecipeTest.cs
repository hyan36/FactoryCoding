using FactoryCodingChallenge.Extensions;
using FactoryCodingChallenge.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryCodingChallenge.Test.Model
{
    public class RecipeTest : TestCaseTemplate
    {
        IRecipe Recipe;

        [SetUp]
        public void SetUp()
        {
            Recipe = new Recipe(RecipesJSON);
        }

        [Test]
        public void TestGetRecipeDictionary()
        {
            var size = RecipesJSON.Keys().Count;
            Assert.AreEqual(Recipe.Recipes.Count, size);
        }

        [Test]
        public void TestGetRecipeCode()
        {
            var code = Recipe.GetCode("recipe_elec_engine");
            var code2 = Recipe.GetCode("electric_engine");
            Assert.AreEqual(code, code2);

            var code3 = Recipe.GetCode("random");
            Assert.AreEqual(code3, "random");
        }

        [Test]
        public void TestGetRecipe()
        {
            var recipe1 = Recipe.GetRecipe("recipe_elec_engine");
            var recipe2 = Recipe.GetRecipe("electric_engine");
            Assert.AreEqual(recipe1.Code, recipe2.Code);

            var recipe3 = Recipe.GetRecipe("random");
            Assert.IsNull(recipe3);
        }


    }
}
