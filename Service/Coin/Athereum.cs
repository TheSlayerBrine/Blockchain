namespace Service.Coin;

public static class Athereum
{
    public static double Value { get; set; }

    static Athereum()
    {
        Value = 3.12;
    }
    public  static double ConvertUSDToAthereum(double amount)
    {
        return amount / Value;
    }

    public static double ConvertAthereumToUSD(double amount)
    {
        return amount * Value;
    }
}