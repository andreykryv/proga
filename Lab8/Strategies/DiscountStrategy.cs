class DiscountStrategy : ICostCalculationStrategy, IDiscountable
{
    private readonly decimal discount;

    internal DiscountStrategy(decimal discount)
    {
        if (discount < 0 || discount > 1)
            throw new ArgumentException("Скидка должна быть в диапазоне [0, 1].");
        this.discount = discount;
    }

    public decimal Discount => discount;

    public decimal Calculate(IBillable client)
    {
        decimal baseCost = client.MonthlyFee + client.TrafficMb * client.PricePerMb;
        return baseCost * (1 - discount);
    }

    public decimal ApplyDiscount(decimal amount) => amount * (1 - discount);
}