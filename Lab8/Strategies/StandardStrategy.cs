class StandardStrategy : ICostCalculationStrategy
{
    public decimal Calculate(IBillable client)
    {
        return client.MonthlyFee + client.TrafficMb * client.PricePerMb;
    }
}