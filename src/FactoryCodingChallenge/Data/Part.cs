using FactoryCodingChallenge.Extensions;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FactoryCodingChallenge.Data
{
    public class Part
    {
        public string Code { get; }
        public string Title { get; }
        public double Time { get; }
        public Dictionary<string, int> Consumes { get; }
        public Dictionary<string, int> Produces { get; }
        public Part(string code, JObject json)
        {
            Code = code;
            Title = json["title"]?.ToString();
            Time = double.Parse(json["time"]?.ToString());
            Consumes = ((JObject) json["consumes"])?.ToDictionary();
            Produces = ((JObject)json["produces"])?.ToDictionary();
        }

        public override string ToString()
        {
            return $"recipe '{Code}' in {Time}s";
        }
    }

}
