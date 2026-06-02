class NightTariffStrategy : ICostCalculationStrategy
{
    public decimal Calculate(decimal monthlyFee, decimal trafficMb, decimal pricePerMb)
        => monthlyFee + trafficMb * pricePerMb * 0.5m;

    
    
    public decimal EffectiveDiscount => 0.5m;
    public string  DiscountLabel     => "ночной тариф";
}