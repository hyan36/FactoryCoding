using FactoryCodingChallenge.Extensions;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace FactoryCodingChallenge.Model
{
    public class Inventory : IInventory
    {
        public Dictionary<string, int> Stocks { get; }

        public Inventory(JObject json)
        {
            Stocks = json.ToDictionary();
        }

        public bool RequestStock(string key, int number)
        {
            var currentStock = Stocks.ContainsKey(key) ? Stocks[key] : 0;
            var newStock = currentStock - number;
            var available = newStock > 0;            
            return available;
        }

        public void FetchStock(string key, int number) 
        {
            var currentStock = Stocks[key];
            var newStock = currentStock - number;
            var available = newStock > 0;
            Stocks[key] = available ? currentStock - number : currentStock;
        }

        public void AddStock(string key, int number)
        {
            var currentStock = Stocks.ContainsKey(key) ? Stocks[key] : 0;
            var newStock = currentStock + number;
            Stocks[key] = newStock;
        }
    }
}
