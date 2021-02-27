using FactoryCodingChallenge.Data;
using FactoryCodingChallenge.Factory;
using FactoryCodingChallenge.Logger;
using FactoryCodingChallenge.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryCodingChallenge
{
    public class App
    {
        protected IAutoFactory AutoFactory { get; set; }

        protected ILogger Logger { get; }

        protected Configuration Config { get; }

        public App(Configuration config, ILogger logger)
        {
            Config = config;
            Logger = logger;
            Init();
        }

        public void Init()
        {
            var inventories = new Inventory(GetJObjectByPath(Config.InventoryPath));
            Logger.Log($"Inventory loaded: {inventories.Stocks.Count} unique components");
            var recipes = new Recipe(GetJObjectByPath(Config.RecipesPath));

            Logger.Log($"Recipes loaded: {recipes.Recipes.Count} total");
            AutoFactory = new AutoFactory(inventories, recipes, Logger);
        }

        public void Build(string recipe, int qty)
        {
            AutoFactory.Build(recipe, qty);
        }

        public void PrintInventories()
        {
            Logger.Log(AutoFactory.Inventory);
        }

        protected JObject GetJObjectByPath(string path) => JObject.Parse(File.ReadAllText(path));

    }
}
