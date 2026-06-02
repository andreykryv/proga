class Client : IBillable, IDisplayable, IDiscountable
{
    private int id;
    private string name;
    private Tariff tariff;
    private decimal trafficMb;
    private ICostCalculationStrategy strategy;

    internal Client(int id, string name, Tariff tariff)
    {
        if (id <= 0)
            throw new ArgumentException("ID клиента должен быть положительным числом.");
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя клиента не может быть пустым.");
        if (tariff == null)
            throw new ArgumentNullException(nameof(tariff));

        this.id = id;
        this.name = name;
        this.tariff = tariff;
        this.trafficMb = 0;
        this.strategy = new StandardStrategy();
    }

    public int     Id        => id;
    public string  Name      => name;
    public Tariff  Tariff    => tariff;

    
    public decimal MonthlyFee => tariff.MonthlyFee;
    public decimal TrafficMb  => trafficMb;
    public decimal PricePerMb => tariff.PricePerMb;

    
    public decimal Discount => strategy.EffectiveDiscount;

    public decimal ApplyDiscount(decimal amount) =>
        amount * (1 - Discount);

    
    public decimal? CurrentDiscount =>
        strategy.EffectiveDiscount > 0 ? strategy.EffectiveDiscount : (decimal?)null;

    
    
    public ICostCalculationStrategy GetStrategy() => strategy;

    public void SetStrategy(ICostCalculationStrategy newStrategy)
    {
        strategy = newStrategy ?? throw new ArgumentNullException(nameof(newStrategy));
    }

    
    public decimal CalculateCost() =>
        strategy.Calculate(tariff.MonthlyFee, trafficMb, tariff.PricePerMb);

    
    
    public decimal CalculateBaseCost() =>
        tariff.MonthlyFee + trafficMb * tariff.PricePerMb;

    internal void AddTraffic(decimal mb)
    {
        if (mb < 0)
            throw new ArgumentException("Количество трафика не может быть отрицательным.");
        trafficMb += mb;
    }

    public string GetInfo()
    {
        string discountPart = !string.IsNullOrEmpty(strategy.DiscountLabel)
            ? $" | Скидка: {strategy.DiscountLabel}"
            : string.Empty;
        return $"Абонент: {name} | ID: {id} | Тариф: {tariff} | " +
               $"Трафик: {trafficMb} МБ | К оплате: {CalculateCost():F2} руб.{discountPart}";
    }
}