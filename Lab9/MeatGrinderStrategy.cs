/// <summary>
/// Стратегия мясорубки (прокрутка мяса через решётку)
/// </summary>
class MeatGrinderStrategy : IProcessingStrategy
{
    public void Process(string processorName)
    {
        Console.WriteLine($"[{processorName}] Мясорубка: прокручиваю мясо через насадку-решётку");
    }
}
