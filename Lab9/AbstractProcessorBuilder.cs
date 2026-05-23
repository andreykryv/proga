/// <summary>
/// Абстрактный строитель кухонного процессора (Builder pattern).
/// </summary>
abstract class AbstractProcessorBuilder
{
    protected string name = string.Empty;
    protected ProcessorType type;
    protected IProcessingStrategy? strategy;

    public AbstractProcessorBuilder SetName(string name)
    {
        this.name = name;
        return this;
    }

    public AbstractProcessorBuilder SetType(ProcessorType type)
    {
        this.type = type;
        return this;
    }

    public AbstractProcessorBuilder SetStrategy(IProcessingStrategy strategy)
    {
        this.strategy = strategy;
        return this;
    }

    /// <summary>Создать конкретный объект процессора</summary>
    public abstract ProcessorBase Build();
}
