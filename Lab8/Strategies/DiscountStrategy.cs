class DiscountStrategy : ICostCalculationStrategy
{
    internal decimal DiscountStrategy(DiscountClient discount)
    {
        this.discount = discount;
    }
    internal decimal Calculate(Client client)
    {
            (client.MonthlyFee + client.TrafficMb * client.PricePerMb) * (1 - discountclient.discount)
    }


}