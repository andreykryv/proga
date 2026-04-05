

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
    if (amount <= 0)
        throw new ArgumentException("Сумма увеличения должна быть положительной.");
    tariffCost += amount;
}
     public static void DecreaseCost(decimal amount)
     {if (amount <= 0)
        throw new ArgumentException("Сумма уменьшения должна быть положительной.");
    if (tariffCost - amount < 0)
        throw new InvalidOperationException("Тариф не может стать отрицательным.");
    tariffCost -= amount;
}






}