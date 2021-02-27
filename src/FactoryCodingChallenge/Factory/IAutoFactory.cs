using FactoryCodingChallenge.Model;

namespace FactoryCodingChallenge.Factory
{
    public interface IAutoFactory
    {
        IInventory Inventory { get; }
        IRecipe Recipe { get; }

        void Build(string code, int qty);
    }
}