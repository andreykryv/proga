


interface IDiscountable
{
    decimal Discount { get; }                   
    decimal ApplyDiscount(decimal amount);      
}