interface ICostCalculationStrategy
{
    decimal Calculate(decimal monthlyFee, decimal trafficMb, decimal pricePerMb);

    
    decimal EffectiveDiscount { get; }

    
    string DiscountLabel { get; }
}