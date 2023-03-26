using System.Collections.ObjectModel;

namespace EconomyModellingEngine.Domain;

internal class Person
{
    public Person(long id, int necessaryConsumption, OutputCapacity output, int necessaryStockpile)
    {
        Id = id;
        NecessaryConsumption = necessaryConsumption;
        OutputCapacity = output;
        NecessaryStockpile = necessaryStockpile;
    }

    public long Id { get; }
    public int NecessaryConsumption { get; }
    public OutputCapacity OutputCapacity { get; private set; }
    private int NecessaryStockpile { get; set; }

    public MarketBid GetBidForPrice(double marketPriceNecessaryForLuxury)
    {
        NecessaryAndLuxury outputForPrice = OutputCapacity.OutputForMarketPrice(marketPriceNecessaryForLuxury);
        int requirement = NecessaryConsumption - outputForPrice.Necessary;
        MarketBid bid = new(outputForPrice, requirement);
        return bid;
    }

    public PersonOutputPerTick RunOneTick(MarketMaker marketMaker)
    {
        //produce
        NecessaryAndLuxury production = OutputCapacity.OutputForMarketPrice(marketMaker.MarketPriceNecessaryForLuxury);
        NecessaryAndLuxury receivedGoods = marketMaker.TradeProductionForGoods(production, NecessaryConsumption);

        //consume
        if (NecessaryConsumption > NecessaryStockpile) throw new Exception("Can't consume necessary.");
        NecessaryStockpile -= NecessaryConsumption;
        NecessaryStockpile += receivedGoods.Necessary;

        PersonOutputPerTick output = new(NecessaryStockpile, receivedGoods);
        return output;
    }

    //private NecessaryAndLuxury Produce()
    //{
    //    int numNecessaryGoodsNeededToBeHappy = Math.Max(Constants.NecessaryGoodsToBeHappy - Stockpile.Necessary, 0);

    //    NecessaryAndLuxury output = OutputCapacity.ProduceOutput(numNecessaryGoodsNeededToBeHappy);
    //    return output;
    //}
}

internal class PersonKeyedCollection : KeyedCollection<long, Person>
{
    protected override long GetKeyForItem(Person item)
    {
        return item.Id;
    }
}
