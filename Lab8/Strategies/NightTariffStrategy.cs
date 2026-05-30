class NightTariffStrategy : ICostCalculationStrategy
{
    public decimal Calculate(IBillable client)
    {
        return client.MonthlyFee + client.TrafficMb * client.PricePerMb * 0.5m;
    }
}