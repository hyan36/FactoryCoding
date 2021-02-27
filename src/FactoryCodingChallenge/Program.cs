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
            var app = new App(
                new Data.Configuration()
                {
                    InventoryPath = ".\\config-inventory.json",
                    RecipesPath = ".\\config-recipes.json"
                },
                new ConsoleLogger()
            );

            app.PrintInventories();

            app.Build("electric_engine", 3);

            app.PrintInventories();

        }
    }
}
