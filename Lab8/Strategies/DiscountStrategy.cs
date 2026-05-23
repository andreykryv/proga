/// <summary>Стратегия со скидкой: применяет фиксированный процент к итоговой сумме.</summary>
class DiscountStrategy : ICostCalculationStrategy
{
    private readonly decimal discount;

    /// <param name="discount">Коэффициент скидки от 0 до 1, например 0.15 = 15%.</param>
    internal DiscountStrategy(decimal discount)
    {
        if (discount < 0 || discount > 1)
            throw new ArgumentException("Скидка должна быть в диапазоне [0, 1].");
        this.discount = discount;
    }

    public decimal Discount => discount;

    public decimal Calculate(Client client)
    {
        decimal baseCost = client.Tariff.MonthlyFee + client.TrafficMb * client.Tariff.PricePerMb;
        return baseCost * (1 - discount);
    }
}