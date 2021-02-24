using FactoryCodingChallenge.Data;
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

        public void Log(int layer, Part part)
        {
            var tabs = string.Empty;
            while (layer > 0)
            {
                tabs += "\t";
                layer--;
            }
            Log($"{tabs} building {part}");
        }
    }
}
