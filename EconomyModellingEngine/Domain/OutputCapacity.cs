namespace EconomyModellingEngine.Domain;

internal class OutputCapacity
{
    public OutputCapacity(int goodsOutputCapacity)
    {
        GoodsOutputCapacity = goodsOutputCapacity;
    }

    public int GoodsOutputCapacity { get; }

    public NecessaryAndLuxury ProduceOutput(int necessaryGoodsNeeded)
    {
        int necessaryGoodsProduced = Math.Min(necessaryGoodsNeeded, GoodsOutputCapacity);
        int luxuryGoodsProduced = GoodsOutputCapacity - necessaryGoodsProduced;

        NecessaryAndLuxury necessaryAndLuxury = new(necessaryGoodsProduced, luxuryGoodsProduced);
        return necessaryAndLuxury;
    }
}