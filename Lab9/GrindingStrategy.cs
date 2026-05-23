/// <summary>
/// Стратегия измельчения (перемол в мелкую крошку или порошок)
/// </summary>
class GrindingStrategy : IProcessingStrategy
{
    public void Process(string processorName)
    {
        Console.WriteLine($"[{processorName}] Измельчение: перемалываю ингредиенты в мелкую крошку");
    }
}
