using FactoryCodingChallenge.Data;

namespace FactoryCodingChallenge.Logger
{
    public interface ILogger
    {
        void Log(string text);

        void Log(int layer, Part part);
    }
}