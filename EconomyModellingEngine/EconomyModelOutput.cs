namespace EconomyModellingEngine;

public class EconomyModelOutput
{
    public EconomyModelOutput(List<EconomyModelOutputPerTick> output)
    {
        Output = output;
    }

    public List<EconomyModelOutputPerTick> Output { get; }
}
