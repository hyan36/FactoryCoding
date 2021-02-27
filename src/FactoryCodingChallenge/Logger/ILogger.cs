using FactoryCodingChallenge.Data;
using FactoryCodingChallenge.Model;

namespace FactoryCodingChallenge.Logger
{
    public interface ILogger
    {
        void Log(string text);

        void Log(int layer, Part part, double time, string divider = "\t");

        void Log(IInventory inventory);
    }
}