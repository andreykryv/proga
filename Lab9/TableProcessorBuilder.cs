/// <summary>
/// Строитель настольного процессора
/// </summary>
class TableProcessorBuilder : AbstractProcessorBuilder
{
    public override ProcessorBase Build()
    {
        var processor = new TableProcessor
        {
            Name = name,
            Type = ProcessorType.Desktop
        };
        if (strategy != null)
            processor.SetProcessingStrategy(strategy);
        return processor;
    }
}
