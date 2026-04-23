




class Tariff
{
    private string name;
    private TariffType type;
    private decimal monthlyFee;
    private decimal pricePerMb;


    internal Tariff(string name, TariffType type, decimal monthlyFee, decimal pricePerMb)
    { if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название тарифа не может быть пустым.");
        if (monthlyFee < 0)
            throw new ArgumentException("Абонентская плата не может быть отрицательной.");
        if (pricePerMb < 0)
            throw new ArgumentException("Цена за МБ не может быть отрицательной.");
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