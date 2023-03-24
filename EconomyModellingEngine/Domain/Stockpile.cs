namespace EconomyModellingEngine.Domain;

internal class Stockpile
{
    public Stockpile(NecessaryAndLuxury goods)
    {
        Goods = goods;
    }

    public NecessaryAndLuxury Goods { get; private set; }

    public void Consume(NecessaryAndLuxury goods)
    {
        if (Goods.Necessary < goods.Necessary) throw new Exception("Could not consume necessary level");
        Goods.MinusUpToZero(goods);
    }
}
