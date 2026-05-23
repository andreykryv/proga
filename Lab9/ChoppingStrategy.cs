/// <summary>
/// Стратегия шинкования (нарезка тонкими ломтиками)
/// </summary>
class ChoppingStrategy : IProcessingStrategy
{
    public void Process(string processorName)
    {
        Console.WriteLine($"[{processorName}] Шинкование: нарезаю овощи тонкими ломтиками");
    }
}
