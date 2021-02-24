using FactoryCodingChallenge.Factory;
using FactoryCodingChallenge.Logger;
using FactoryCodingChallenge.Model;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Json;
using System.Text.Json;

namespace FactoryCodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText(".\\config-inventory.json");
            var json = JObject.Parse(text);
            var inventory = new Inventory(json);

            var text2 = File.ReadAllText(".\\config-recipes.json");
            var json2 = JObject.Parse(text2);
            var recipe = new Recipe(json2);

            var factory = new AutoFactory(inventory, recipe, new ConsoleLogger());
            factory.Build("electric_engine", 3);
            Console.WriteLine("Hello World!");
        }
    }
}
