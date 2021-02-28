using FactoryCodingChallenge.Data;
using FactoryCodingChallenge.Logger;
using FactoryCodingChallenge.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryCodingChallenge.Factory
{
    public class AutoFactory : IAutoFactory
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
            var built = true;
            while (qty > 0 && built)
            {
                Timer = 0.0;
                var part = Recipe.GetRecipe(code);
                built = Build(Recipe.GetCode(code), 1, 0);
                qty--;
                if (built)
                {
                    Inventory.AddStock(part.Code, 1);
                    Logger.Log($"Built {part.Title} in {Timer}s \n");
                } 
                else
                {
                    Logger.Log($"Insufficient resources to build: {part.Title}");
                }
            }
        }

        public bool Build(string code, int qty, int layer)
        {
            var hasStock = layer > 0 ? Inventory.RequestStock(code, qty) : false;
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
                var producedQty = (int)Math.Ceiling((decimal)qty / part.Produces[code]);
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
                Logger.Log(layer, part, Timer);
            }

            if (!hasStock && recipe == null)
            {
                return false;
            }

            return true;
        }

    }
}
