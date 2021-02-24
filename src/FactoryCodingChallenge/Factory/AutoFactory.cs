using FactoryCodingChallenge.Data;
using FactoryCodingChallenge.Logger;
using FactoryCodingChallenge.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryCodingChallenge.Factory
{
    public class AutoFactory
    {
        public IInventory Inventory { get; }

        public IRecipe Recipe { get; }

        public ILogger Logger { get; }

        protected double Timer { get; set; }

        public AutoFactory(IInventory inventory, IRecipe recipe, ILogger logger)
        {
            Inventory = inventory;
            Recipe = recipe;
            Logger = logger;
        }

        public void Build(string code, int qty)
        {
            Timer = 0.0;
            var canBuild = true;
            while(qty > 0 && canBuild)
            {
                var part = Recipe.GetRecipe(code);
                canBuild = Build(code, 1, 0);
                qty--;
            }
        }

        public bool Build(string code, int qty, int layer)
        {
            var hasStock = Inventory.RequestStock(code, qty);
            var recipe = Recipe.GetRecipe(code);

            if (hasStock)
            {
                Inventory.FetchStock(code, qty);
                return true;
            }

            if (!hasStock && recipe != null)
            {
                var part = recipe;
                Timer += part.Time;
                var producedQty = (int) Math.Ceiling((decimal)qty / part.Produces[code]);
                Logger.Log(layer, part);
                foreach (var consume in part.Consumes)
                {
                    var consumeQty = consume.Value;
                    var partsNeeded = producedQty * consumeQty;
                    if (!Build(consume.Key, partsNeeded, layer + 1))
                    {
                        return false;
                    }
                }
                Inventory.AddStock(code, qty - producedQty);
            }

            if (!hasStock && recipe == null)
            {
                return false;
            }

            return true;
        }
        
    }
}
