using FactoryCodingChallenge.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryCodingChallenge.Extensions
{
    public static class JObjectExtensions
    {

        public static List<string> Keys(this JObject json) 
            => json?.Properties()?
            .Select(p => p.Name)?.ToList();

        public static Dictionary<string, int> ToDictionary(this JObject json) 
            => json?.Keys()
            .ToDictionary(key => key, key => int.Parse(json[key]?.ToString()));

        public static Part ToComponent(this JObject json, string code) => new Part(code, json);

        public static Dictionary<string, Part> ToRecipes(this JObject json)
           => json?.Keys()
            .ToDictionary(key => key, key => ((JObject) json[key])?.ToComponent(key));

    }
}
