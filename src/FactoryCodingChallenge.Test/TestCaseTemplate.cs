using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryCodingChallenge.Test
{
    public class TestCaseTemplate
    {
        protected JObject GetJObjectByPath(string path) => JObject.Parse(File.ReadAllText(path));

        protected char PathSeperator => Path.DirectorySeparatorChar;

        protected JObject RecipesJSON => GetJObjectByPath($".{PathSeperator}config-recipes.json");

        protected JObject InventoryJSON => GetJObjectByPath($".{PathSeperator}config-inventory.json");
    }
}
