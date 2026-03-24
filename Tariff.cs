


using System.ComponentModel;

class Tariff
{
    private string name;
    private internal TariffType.TariffType type;
    private decimal monthlyFee;
    private decimal pricePerMb;


    public Tariff(string name, TariffType.TariffType type, decimal monthlyFee, decimal pricePerMb)
    {
        this.name = name;
        this.type = type;
        this.monthlyFee = monthlyFee;
        this.pricePerMb = pricePerMb;
    }

    public string Name => name;
    private internal TariffType Type => type;
    public decimal MonthlyFee => monthlyFee;
    public decimal PricePerMb => pricePerMb;
    
     public override string ToString()
    {
        return $"{name} ({type}) — абон. плата: {monthlyFee} руб., за МБ: {pricePerMb} руб.";
    }
}