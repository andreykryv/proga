



using System.Data.Common;
using System.Dynamic;
using System.IO.Pipelines;

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
        trafficMb += mb;
       
    }
    internal decimal CalculateCost()
    {
         decimal result = tariff.MonthlyFee + trafficMb * tariff.PricePerMb;
        return result;
    }
}