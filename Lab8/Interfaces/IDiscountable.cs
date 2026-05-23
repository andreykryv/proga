interface IDiscountable
{
    decimal ApplyDiscount(decimal amount); 
    decimal Discount{get;}
}