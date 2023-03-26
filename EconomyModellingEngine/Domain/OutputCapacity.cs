using System.Runtime.CompilerServices;

namespace EconomyModellingEngine.Domain;

internal class OutputCapacity
{
    public OutputCapacity(NecessaryAndLuxury goodsOutputCapacity)
    {
        GoodsOutputCapacity = goodsOutputCapacity;
    }

    public NecessaryAndLuxury GoodsOutputCapacity { get; }

    public NecessaryAndLuxury ProduceOutput(int necessaryGoodsNeeded)
    {
        int necessaryGoodsProduced = Math.Min(necessaryGoodsNeeded, GoodsOutputCapacity.Necessary);
        int luxuryGoodsProduced = GoodsOutputCapacity.Necessary - necessaryGoodsProduced;

        NecessaryAndLuxury necessaryAndLuxury = new(necessaryGoodsProduced, luxuryGoodsProduced);
        return necessaryAndLuxury;
    }

    public NecessaryAndLuxury OutputForMarketPrice(double marketPriceNecessaryForLuxury) //provided market will provide necessary if not producing myself
    {
        bool wouldProduceNecessary = GoodsOutputCapacity.Luxury * marketPriceNecessaryForLuxury < GoodsOutputCapacity.Necessary;

        if (wouldProduceNecessary)
        {
            return new NecessaryAndLuxury(GoodsOutputCapacity.Necessary, 0);
        }
        else return new NecessaryAndLuxury(0, GoodsOutputCapacity.Luxury);
    }
}