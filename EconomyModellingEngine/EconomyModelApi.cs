namespace EconomyModellingEngine;

public static class EconomyModelApi
{
    public static EconomyModelOutput RunEconomyModelling(IEconomyModelInputs inputs)
    {
        EconomyModelOutput output = BasicEconomyModel.RunBasicEconomyModel(inputs.InputNumber, inputs.InputNumber2);
        return output;

        //Pseudocode
        //People work, for a company, for payment in money, to produce goods for a price
        //People work to spend money on necessary goods, and then work some more to spend money on luxury goods
        //Companies produce necessary goods or luxury goods, maximising profit
        //
        //Each time unit of the economy:
        // - all people contribute their work
        // - they get paid a fixed amount
        // - 
        // - companies and people set prices dependant on the cost to produce & demand level
        //   - cost to produce is a lower bound, competition pushes prices towards this lower bound
        //   - demand is an upper bound, companies will try and charge as high as demand allows
    }
}
