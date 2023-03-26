namespace EconomyModellingEngine.Domain;

internal readonly struct MarketBid
{
    public MarketBid(NecessaryAndLuxury production, int necessaryRequirement)
    {
        Production = production;
        NecessaryRequirement = necessaryRequirement;
    }

    public NecessaryAndLuxury Production { get; }
    public int NecessaryRequirement { get; }
}
