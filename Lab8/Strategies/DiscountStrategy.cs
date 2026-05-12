class DiscountStrategy : ICostCalculationStrategy
{
    internal decimal DiscountStrategy(DiscountClient discount)
    {
        this.discount = discount;
    }
    public decimal Calculate(IBillable client)
    {
            (client.MonthlyFee + client.TrafficMb * client.PricePerMb) * (1 - discountclient.discount);
    }


}