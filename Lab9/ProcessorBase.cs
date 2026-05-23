/// <summary>
/// Абстрактный базовый класс кухонного процессора.
/// Является «мостом» (Bridge abstraction) — хранит ссылку на IProcessingStrategy.
/// </summary>
abstract class ProcessorBase
{
    // ----- общие свойства -----
    public string Name { get; set; } = string.Empty;
    public ProcessorType Type { get; set; }

    // ----- Bridge: реализация обработки -----
    private IProcessingStrategy? _strategy;

    /// <summary>
    /// Установить режим обработки продуктов (Bridge pattern)
    /// </summary>
    public void SetProcessingStrategy(IProcessingStrategy strategy)
    {
        _strategy = strategy;
    }

    /// <summary>
    /// Запустить обработку продуктов выбранным режимом (общая функция)
    /// </summary>
    public void Process()
    {
        if (_strategy == null)
            Say("Режим обработки не задан — установите стратегию!");
        else
            _strategy.Process(Name);
    }

    // ----- абстрактный метод, переопределяется в каждом наследнике -----
    public abstract void GetInfo();

    // ----- вспомогательный метод вывода -----
    protected void Say(string message)
    {
        Console.WriteLine($"[{Name}]: {message}");
    }
}
