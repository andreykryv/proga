/// <summary>
/// Стратегия нарезки кубиками
/// </summary>
class SlicingStrategy : IProcessingStrategy
{
    public void Process(string processorName)
    {
        Console.WriteLine($"[{processorName}] Нарезка: нарезаю ингредиенты аккуратными кубиками");
    }
}
