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

//Assumption
//Everyone is self-sufficient, it's the interaction between the price for luxury goods that will be interesting
//You need the people making decisions based on the market price, and the market price adjusting to the decisions of the people (to produce either Luxury or Necessary)

//Introduce dynamic demand for Luxuries
//People will seek to consume more luxuries if more are available

//Introduce money
//People will have money rather than stockpiles of goods (or both!)

//Introduce specialisation
//People can become better at creating either Luxury or Necessary.  The overall economy grows.
//Mechanism for the economy to make enough "Necessary" goods?
//
//Introduce trading rate
//Goods can be exchanged at the going rate
//Individuals will maximise profit - producing goods that can be traded