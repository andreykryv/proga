


class Client
{
     private int id;
     private string name;
     private Tariff tariff;
 
     private decimal trafficMb;


     internal Client(int id,string name, Tariff tariff)
    {
        this.id = id;
        this.name = name;
        this.tariff = tariff;
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
         decimal result = tariff.MonthlyFee + trafficMb * tariff.PricePerMb;
        return result;
    }
     public override string ToString()
    {
        return $"Абонент:{name} id:{id} тариф:{tariff} использовано интернета:{trafficMb} ";
    }
}