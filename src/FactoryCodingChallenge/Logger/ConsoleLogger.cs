using FactoryCodingChallenge.Data;
using FactoryCodingChallenge.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryCodingChallenge.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }

        public void Log(int layer, Part part, double time, string spacer = "\t")
        {
            var tabs = string.Empty;
            while (layer > 0)
            {
                tabs += spacer;
                layer--;
            }
            Log($"{tabs} {part} ({time}s total)");
        }

        public void Log(IInventory inventory)
        {
            Log($"Inventory:\n{inventory}");
        }
    }
}
