using CommandLine;
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

        public class Options
        {
            [Option("cp", Required = false, HelpText = "The path of configuration files")]
            public string ConfigPath { get; set; }

            [Option('b', "build", Required = true, HelpText = "Build component")]
            public string Build { get; set; }

            [Option('q', "qty", Required = true, HelpText = "Quantity required")]
            public int Qty { get; set; }
        }

        static char PathSeperator => Path.DirectorySeparatorChar;

        static string GetConfigurationFile(string configPath, string filename) 
            => string.IsNullOrEmpty(configPath) ? $".{PathSeperator+filename}" : $"{configPath+PathSeperator+filename}";

        static void Main(string[] args)
        {
          
            Parser
                .Default
                .ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                 {
                     var inventory = GetConfigurationFile(o.ConfigPath, "config-inventory.json");
                     var recipes = GetConfigurationFile(o.ConfigPath, "config-recipes.json");
                     var app = new App(
                          new Data.Configuration()
                          {
                              InventoryPath = inventory,
                              RecipesPath = recipes
                          },
                          new ConsoleLogger()
                     );
                     
                     app.PrintInventories();

                     app.Build(o.Build, o.Qty);

                     app.PrintInventories();
                 });

        }

        
    }
}
