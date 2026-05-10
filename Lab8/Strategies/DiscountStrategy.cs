class DiscountStrategy : ICostCalculationStrategy
{
    internal DiscountStrategy(DiscountClient discount)
    {
        this.discount = discount;
    }

    (MonthlyFee + TrafficMb * PricePerMb) * (1 - discount)
}