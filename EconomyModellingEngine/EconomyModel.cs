namespace EconomyModellingEngine;

public static class EconomyModel
{
    public static EconomyModelOutput RunEconomyModelling(IEconomyModelInputs inputs)
    {
        int output = inputs.InputNumber * inputs.InputNumber2;
        return new EconomyModelOutput(output);
    }
}
