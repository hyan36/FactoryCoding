using FactoryCodingChallenge.Extensions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryCodingChallenge.Test.Extensions
{
    public class JObjectExtensionsTest : TestCaseTemplate
    {
        [Test]
        public void TestGetKeysFromJsonObject()
        {
            var dictionary = InventoryJSON.ToDictionary();
            var keys = InventoryJSON.Keys();
            Assert.AreEqual(InventoryJSON.Keys().Count, 5);
            foreach(var key in keys)
            {
                Assert.IsTrue(dictionary.ContainsKey(key));
            }
        }

        [Test]
        public void TestGetRecipesDictionaryFromJsonObject()
        {
            var recipes = RecipesJSON.ToRecipes();
            var keys = RecipesJSON.Keys();
            foreach (var key in keys)
            {
                Assert.IsTrue(recipes.ContainsKey(key));
            }
        }
    }
}
