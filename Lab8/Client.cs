class Client : IDisplayable, IBillable
{
    private int id;
    private string name;
    private Tariff tariff;
    private decimal trafficMb;

    
 protected ICostCalculationStrategy strategy;
 

    internal Client(int id, string name, Tariff tariff)
    {
        if (id <= 0)
            throw new ArgumentException("ID клиента должен быть положительным числом.");
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя клиента не может быть пустым.");
        if (tariff == null)
            throw new ArgumentNullException(nameof(tariff), "Тариф не может быть null.");

        this.id = id;
        this.name = name;
        this.tariff = tariff;
        this.trafficMb = 0;
         this.strategy = new StandardStrategy();
    }

    public int Id => id;
    public string Name => name;
    public Tariff Tariff => tariff;
    public decimal TrafficMb => trafficMb;

    // IBillable
    public decimal MonthlyFee => tariff.MonthlyFee;
    public decimal PricePerMb => tariff.PricePerMb;
public decimal CalculateCost() => strategy.Calculate(this);

    
public decimal? CurrentDiscount => (strategy as DiscountStrategy)?.Discount;
    internal void SetStrategy(ICostCalculationStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    internal void AddTraffic(decimal mb)
    {
        if (mb < 0)
            throw new ArgumentException("Количество трафика не может быть отрицательным.");
        trafficMb += mb;
    }

    // Полиморфный метод: переопределяется в DiscountClient


    // IDisplayable
    public string GetInfo()
    {
        return $"Абонент: {name} | ID: {id} | Тариф: {tariff} | Трафик: {trafficMb} МБ | К оплате: {CalculateCost():F2} руб.";
    }
}