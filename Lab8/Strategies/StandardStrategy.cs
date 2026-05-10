class StandardStrategy : ICostCalculationStrategy
{
    internal decimal Calculate(Client client)
    {
        return client.Tariff.MonthlyFee + client.TrafficMb * client.Tariff.PricePerMb;
    }
}