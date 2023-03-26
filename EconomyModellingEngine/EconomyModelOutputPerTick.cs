using EconomyModellingEngine.Domain;

namespace EconomyModellingEngine;

public class EconomyModelOutputPerTick
{
    public EconomyModelOutputPerTick(IReadOnlyDictionary<long, PersonOutputPerTick> peopleResults, double marketPrice,
        NecessaryAndLuxury marketMakerStockpile)
    {
        PeopleResults = peopleResults;
        MarketPrice = marketPrice;
        MarketMakerStockpile = marketMakerStockpile;
    }

    public IReadOnlyDictionary<long, PersonOutputPerTick> PeopleResults { get; }
    public double MarketPrice { get; }
    public NecessaryAndLuxury MarketMakerStockpile { get; }
}

public class PersonOutputPerTick
{
    public PersonOutputPerTick(int necessaryStockPileAtEnd, NecessaryAndLuxury consumption)
    {
        NecessaryStockPileAtEnd = necessaryStockPileAtEnd;
        Consumption = consumption;
    }

    public int NecessaryStockPileAtEnd { get; }
    public NecessaryAndLuxury Consumption { get; }
}