using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

class Tariff
{
    
     private static decimal tariffCost;
     public static decimal TariffCost
     {
          get{ return tariffCost;}
          
     }
      
     public Tariff()
     {    tariffCost = 20.00m;
     }
     public Tariff(decimal cost)
     {   tariffCost = cost;
     }


     public static void IncreaseCost(decimal amount)
     {  
          tariffCost += amount;
     }
     public static void DecreaseCost(decimal amount)
     {
           
     
        tariffCost -= amount;
}






}