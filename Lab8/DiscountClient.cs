class DiscountClient : Client
{
    private const decimal discount = 0.15m;


    internal DiscountClient(int discount)
    {
        this.discount = discount;
    }
    
    public decimal Discount => discount;

    internal override decimal CalculateCost()
    {
        
    }
    internal void ApplyDiscount()
    {
        
    }
     


}