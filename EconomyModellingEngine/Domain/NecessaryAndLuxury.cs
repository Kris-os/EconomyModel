namespace EconomyModellingEngine.Domain;

public readonly struct NecessaryAndLuxury
{
    public NecessaryAndLuxury(int necessary, int luxury)
    {
        Necessary = necessary;
        Luxury = luxury;
    }

    public int Necessary { get; } 
    public int Luxury { get; }

    public NecessaryAndLuxury Minus(NecessaryAndLuxury toMinus)
    {
        int outputNecessary = Necessary - toMinus.Necessary;
        int outputLuxury = Luxury - toMinus.Luxury;
        return new NecessaryAndLuxury(outputNecessary, outputLuxury);
    }

    public NecessaryAndLuxury MinusUpToZero(NecessaryAndLuxury toMinus)
    {
        int outputNecessary = Necessary - Math.Min(toMinus.Necessary, Necessary);
        int outputLuxury = Luxury - Math.Min(toMinus.Luxury, Luxury);
        NecessaryAndLuxury output = new(outputNecessary, outputLuxury);
        return output;
    }

    public NecessaryAndLuxury Add(NecessaryAndLuxury toAdd)
    {
        int outputNecessary = Necessary + toAdd.Necessary;
        int outputLuxury = Luxury + toAdd.Luxury;
        NecessaryAndLuxury output = new(outputNecessary, outputLuxury);
        return output;
    }

    public static NecessaryAndLuxury operator -(NecessaryAndLuxury a, NecessaryAndLuxury b)
    => new(a.Luxury - b.Luxury, a.Necessary - b.Necessary);
}
