using System.Collections.Generic;

namespace FactoryCodingChallenge.Model
{
    public interface IInventory
    {
        Dictionary<string, int> Stocks { get; }

        bool RequestStock(string key, int number);

        void FetchStock(string key, int number);

        void AddStock(string key, int number);

    }
}