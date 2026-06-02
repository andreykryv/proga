class DiscountStrategy : ICostCalculationStrategy, IHasDiscount
{
    private readonly decimal discount;

    internal DiscountStrategy(decimal discount)
    {
        if (discount < 0 || discount > 1)
            throw new ArgumentException("Скидка должна быть в диапазоне [0, 1].");
        this.discount = discount;
    }

    public decimal Discount          => discount;               
    public decimal EffectiveDiscount => discount;               
    public string  DiscountLabel     => $"скидка {discount:P0}"; 

    public decimal Calculate(decimal monthlyFee, decimal trafficMb, decimal pricePerMb)
    {
        decimal baseCost = monthlyFee + trafficMb * pricePerMb;
        return baseCost * (1 - discount);
    }
}