namespace EconomyModellingEngine.Domain;

internal class Economy
{
    public Economy(IReadOnlyList<Person> people)
    {
        People = people;
    }

    private IReadOnlyList<Person> People { get; }

    public static Economy SetupBasicEconomy(int numPeople)
    {
        List<Person> people = GetListOfPeopleForBasicEconomy(numPeople);
        Economy economy = new(people);
        return economy;
    }

    private static List<Person> GetListOfPeopleForBasicEconomy(int numPeople)
    {
        List<Person> people = new(numPeople);
        for (int i = 0; i < numPeople; i++)
        {
            NecessaryAndLuxury consumption = new(10, 1);
            NecessaryAndLuxury stockpile = new(10, 10);
            Person newPerson = new(i, consumption, new OutputCapacity(12), stockpile);
            people.Add(newPerson);
        }
        return people;
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

    private EconomyModelOutputPerTick RunOneTick()
    {
        Dictionary<long, PersonOutputPerTick> peopleOutput = new();

        foreach (Person person in People)
        {
            PersonOutputPerTick personOutput = person.RunOneTick();
            peopleOutput.Add(person.Id, personOutput);
        }

        EconomyModelOutputPerTick output = new(peopleOutput);
        return output;
    }
}
