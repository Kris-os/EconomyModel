using System.Collections.ObjectModel;

namespace EconomyModellingEngine.Domain;

internal class Person
{
    public Person(long id, NecessaryAndLuxury consumption, OutputCapacity output, NecessaryAndLuxury stockpile)
    {
        Id = id;
        Consumption = consumption;
        OutputCapacity = output;
        Stockpile = stockpile;
    }

    public PersonOutputPerTick RunOneTick()
    {
        //consume
        Stockpile = Stockpile.MinusUpToZero(Consumption);

        //produce
        NecessaryAndLuxury production = Produce();
        Stockpile = Stockpile.Add(production);

        PersonOutputPerTick output = new(Stockpile);
        return output;
    }

    private NecessaryAndLuxury Produce()
    {
        int numNecessaryGoodsNeededToBeHappy = Math.Max(Constants.NecessaryGoodsToBeHappy - Stockpile.Necessary, 0);

        NecessaryAndLuxury output = OutputCapacity.ProduceOutput(numNecessaryGoodsNeededToBeHappy);
        return output;
    }

    public long Id { get; }
    public NecessaryAndLuxury Consumption { get; }
    public OutputCapacity OutputCapacity { get; private set; }
    private NecessaryAndLuxury Stockpile { get; set; }
}

internal class PersonKeyedCollection : KeyedCollection<long, Person>
{
    protected override long GetKeyForItem(Person item)
    {
        return item.Id;
    }
}
