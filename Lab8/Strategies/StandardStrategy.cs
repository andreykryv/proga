class StandardStrategy : ICostCalculationStrategy
{
    public decimal Calculate(decimal monthlyFee, decimal trafficMb, decimal pricePerMb)
        => monthlyFee + trafficMb * pricePerMb;

    public decimal EffectiveDiscount => 0m;
    public string  DiscountLabel     => string.Empty;
}