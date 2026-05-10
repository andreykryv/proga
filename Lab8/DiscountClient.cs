class DiscountClient : Client
{
    private decimal discount = 0.15m;


    internal DiscountClient(decimal discount)
    {
        base(discount);
    }
    
    public decimal Discount => discount;

    internal override decimal CalculateCost()
    {
        
    }
    internal void ApplyDiscount()
    {
        
    }
     


}