using FactoryCodingChallenge.Data;
using System.Collections.Generic;

namespace FactoryCodingChallenge.Model
{
    public interface IRecipe
    {
        Dictionary<string, Part> Recipes { get; }
        Part GetRecipe(string code);
    }
}