class StandardStrategy : ICostCalculationStrategy
{
    public decimal Calculate(Client client)
    {   
        return client.Tariff.MonthlyFee + client.TrafficMb * client.Tariff.PricePerMb;
    }
}