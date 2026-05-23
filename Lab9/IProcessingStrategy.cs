/// <summary>
/// Интерфейс стратегии обработки (Bridge pattern - реализация)
/// </summary>
interface IProcessingStrategy
{
    void Process(string processorName);
}
