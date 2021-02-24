using FactoryCodingChallenge.Data;
using FactoryCodingChallenge.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Json;
using System.Text;

namespace FactoryCodingChallenge.Model
{
    public class Recipe : IRecipe
    {
        public Dictionary<string, Part> Recipes { get; }

        public Dictionary<string, string> Lookup { get; }
   
        public Recipe(JObject json)
        {
            Lookup = new Dictionary<string, string>();
            Recipes = new Dictionary<string, Part>();
            foreach (var raw in json.ToRecipes())
            {
                var component = raw.Value;
                var Produces = component.Produces;
                foreach (var produce in Produces)
                {
                    Recipes[produce.Key] = component;
                    Lookup[raw.Key] = produce.Key;
                }
            }
        }
        public Part GetRecipe(string code) {
            var key = Lookup.ContainsKey(code) ? Lookup[code] : code;            
            return Recipes.ContainsKey(key) ? Recipes[key] : null;
        }
    }
}
