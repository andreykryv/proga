/// <summary>
/// Клиент с фиксированной скидкой.
/// Реализует IDiscountable (явная реализация для демонстрации кастинга).
/// </summary>
class DiscountClient : Client, IDiscountable
{
    private readonly decimal discount;

    internal DiscountClient(int id, string name, Tariff tariff, decimal discount)
        : base(id, name, tariff)
    {
        if (discount < 0 || discount > 1)
            throw new ArgumentException("Скидка должна быть в диапазоне [0, 1].");
        this.discount = discount;
    }

    // IDiscountable — явная реализация (explicit interface implementation)
    // Доступна только через ссылку типа IDiscountable
    decimal IDiscountable.Discount => discount;

    decimal IDiscountable.ApplyDiscount(decimal amount) => amount * (1 - discount);

    // Удобный доступ без кастинга
    public decimal Discount => discount;

    // Переопределение полиморфного метода
    public override decimal CalculateCost()
    {
        decimal baseCost = base.CalculateCost();
        // Применяем скидку через интерфейс — демонстрация кастинга
        IDiscountable discountable = this;
        return discountable.ApplyDiscount(baseCost);
    }

    public new string GetInfo()
    {
        return base.GetInfo() + $" | Скидка: {discount:P0}";
    }
}