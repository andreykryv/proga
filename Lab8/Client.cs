class Client : IDisplayable, IBillable
{
    private int id;
    private string name;
    private Tariff tariff;
    private decimal trafficMb;
    // Strategy pattern: стратегия расчёта стоимости, меняется в runtime
    private ICostCalculationStrategy? strategy;

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
    }

    public int Id => id;
    public string Name => name;
    public Tariff Tariff => tariff;
    public decimal TrafficMb => trafficMb;

    // IBillable
    public decimal MonthlyFee => tariff.MonthlyFee;
    public decimal PricePerMb => tariff.PricePerMb;

    /// <summary>Установить стратегию расчёта — Strategy pattern.</summary>
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
    public virtual decimal CalculateCost()
    {
        // Если стратегия задана — делегируем ей (Strategy pattern)
        if (strategy != null)
            return strategy.Calculate(this);

        // Стандартный расчёт по умолчанию
        return tariff.MonthlyFee + trafficMb * tariff.PricePerMb;
    }

    // IDisplayable
    public string GetInfo()
    {
        return $"Абонент: {name} | ID: {id} | Тариф: {tariff} | Трафик: {trafficMb} МБ | К оплате: {CalculateCost():F2} руб.";
    }
}