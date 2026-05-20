class DiscountClient : Client
{
    private decimal discount = 0.15m;


    internal DiscountClient(int id, string name, Tariff tariff,decimal discount)
    :base(id,name,tariff)
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