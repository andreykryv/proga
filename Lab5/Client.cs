class Client
{
    private int id;
    private string name;
    private Tariff tariff;
    private decimal trafficMb;

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

    internal void AddTraffic(decimal mb)
    {
        if (mb < 0)
            throw new ArgumentException("Количество трафика не может быть отрицательным.");
        trafficMb += mb;
    }

    internal decimal CalculateCost()
    {
        return tariff.MonthlyFee + trafficMb * tariff.PricePerMb;
    }

    public override string ToString()
    {
        return $"Абонент:{name} id:{id} тариф:{tariff} использовано интернета:{trafficMb}";
    }
}