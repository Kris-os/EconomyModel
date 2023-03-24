using EconomyModellingEngine.Domain;

namespace EconomyModellingEngine;

public class EconomyModelOutputPerTick
{
    public EconomyModelOutputPerTick(IReadOnlyDictionary<long, PersonOutputPerTick> peopleResults)
    {
        PeopleResults = peopleResults;
    }

    public IReadOnlyDictionary<long, PersonOutputPerTick> PeopleResults { get; }
}

public class PersonOutputPerTick
{
    public PersonOutputPerTick(NecessaryAndLuxury stockPileAtEnd)
    {
        StockPileAtEnd = stockPileAtEnd;
    }

    public NecessaryAndLuxury StockPileAtEnd { get; }
}