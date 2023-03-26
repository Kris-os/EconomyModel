namespace EconomyModellingEngine.Domain;

internal class MarketMaker
{
    public MarketMaker(IReadOnlyList<Person> people)
    {
        _people = people;
        int amountOfNecessaryGoodsToStart = people.Count * Constants.NecessaryGoodsToBeHappy;
        NecessaryAndLuxury startGoodsStockpile = new(amountOfNecessaryGoodsToStart, amountOfNecessaryGoodsToStart);
        Stockpile = startGoodsStockpile;
    }

    public double MarketPriceNecessaryForLuxury { get; private set; }
    public NecessaryAndLuxury Stockpile { get; private set; }
    private readonly IReadOnlyList<Person> _people;

    public void SetPrice()
    {
        double runningPriceNecessaryForLuxury = 10;

        for (int i = 0; i < 100; i++)
        {
            bool isValid = IsMarketPriceValid(runningPriceNecessaryForLuxury);
            if (isValid)
            {
                MarketPriceNecessaryForLuxury = runningPriceNecessaryForLuxury;
                return;
            }
            runningPriceNecessaryForLuxury -= 0.1;
        }

        throw new Exception("No valid market price found");
    }

    private bool IsMarketPriceValid(double startingPriceNecessaryForLuxury)
    {
        int runningNecessaryMarketRequirement = 0;
        int runningNecessaryMarketProduction = 0;
        foreach (Person person in _people)
        {
            MarketBid bid = person.GetBidForPrice(startingPriceNecessaryForLuxury);
            runningNecessaryMarketRequirement += bid.NecessaryRequirement;
            runningNecessaryMarketProduction += bid.Production.Necessary;
        }
        bool isValid = runningNecessaryMarketProduction >= runningNecessaryMarketRequirement;
        return isValid;
    }

    public NecessaryAndLuxury TradeProductionForGoods(NecessaryAndLuxury production, int necessaryConsumption)
    {
        Stockpile = Stockpile.Add(production);

        double productionAsNecessary = production.Luxury * MarketPriceNecessaryForLuxury + production.Necessary;

        double luxuryConsumption = (productionAsNecessary - necessaryConsumption) / MarketPriceNecessaryForLuxury;

        NecessaryAndLuxury consumersConsumption = new(necessaryConsumption, luxuryConsumption);

        Stockpile = Stockpile.Minus(consumersConsumption);

        return consumersConsumption;
    }
}
