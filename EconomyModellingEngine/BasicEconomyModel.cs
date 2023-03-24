using EconomyModellingEngine.Domain;

namespace EconomyModellingEngine;

internal class BasicEconomyModel
{
    public static EconomyModelOutput RunBasicEconomyModel(int numPeople, int numTicks)
    {
        Economy basicEconomy = Economy.SetupBasicEconomy(numPeople);
        EconomyModelOutput results = basicEconomy.Run(numTicks);
        return results;
    }
}
