class NightTariffStrategy : ICostCalculationStrategy
{
    public decimal Calculate(Client client)
    {
         return client.Tariff.MonthlyFee + client.TrafficMb * client.Tariff.PricePerMb * 0.5m;
    }}
    
