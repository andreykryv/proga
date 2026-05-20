class DiscountStrategy : ICostCalculationStrategy


{private readonly decimal _discount;
    internal DiscountStrategy(DiscountClient discount)
    {
        _discount = discount;
    }
     public decimal Discount => discountClient.discount;

    public decimal Calculate(IBillable client)
    {
            return (client.MonthlyFee + client.TrafficMb * client.PricePerMb) * (1 - _discount);
    }


}