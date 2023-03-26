namespace EconomyModellingEngine.Domain;

internal class Economy
{
    public Economy(IReadOnlyList<Person> people)
    {
        People = people;
        MarketMaker = new MarketMaker(people);
    }

    private IReadOnlyList<Person> People { get; }
    private MarketMaker MarketMaker { get; }

    public static Economy SetupBasicEconomy(int numPeople)
    {
        List<Person> people = GetListOfPeopleForBasicEconomy(numPeople);
        Economy economy = new(people);
        return economy;
    }

    public EconomyModelOutput Run(int numTicks)
    {
        List<EconomyModelOutputPerTick> tickOutputs = new(numTicks);
        for (int i = 0; i < numTicks; i++)
        {
            EconomyModelOutputPerTick tickOutput = RunOneTick();
            tickOutputs.Add(tickOutput);
        }
        EconomyModelOutput output = new(tickOutputs);
        return output;
    }

    private static List<Person> GetListOfPeopleForBasicEconomy(int numPeople)
    {
        List<Person> people = new(numPeople);
        for (int i = 0; i < numPeople; i++)
        {
            OutputCapacity outputCapacity = new(new NecessaryAndLuxury(12, 12));
            Person newPerson = new(i, 10, outputCapacity, 10);
            people.Add(newPerson);
        }
        return people;
    }

    private EconomyModelOutputPerTick RunOneTick()
    {
        Dictionary<long, PersonOutputPerTick> peopleOutput = new();

        MarketMaker.SetPrice();

        foreach (Person person in People)
        {
            PersonOutputPerTick personOutput = person.RunOneTick(MarketMaker);
            peopleOutput.Add(person.Id, personOutput);
        }

        EconomyModelOutputPerTick output = new(peopleOutput, MarketMaker.MarketPriceNecessaryForLuxury, MarketMaker.Stockpile);
        return output;
    }
}
