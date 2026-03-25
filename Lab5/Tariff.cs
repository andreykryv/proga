




class Tariff
{
    private string name;
    private TariffType type;
    private decimal monthlyFee;
    private decimal pricePerMb;


    internal Tariff(string name, TariffType type, decimal monthlyFee, decimal pricePerMb)
    {
        this.name = name;
        this.type = type;
        this.monthlyFee = monthlyFee;
        this.pricePerMb = pricePerMb;
    }

    public string Name => name;
    public TariffType Type => type;
    public decimal MonthlyFee => monthlyFee;
    public decimal PricePerMb => pricePerMb;
    
     public override string ToString()
    {
        return $"{name} ({type}) — абон. плата: {monthlyFee} руб., за МБ: {pricePerMb} руб.";
    }
}