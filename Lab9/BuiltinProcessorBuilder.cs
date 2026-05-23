/// <summary>
/// Строитель встроенного процессора
/// </summary>
class BuiltinProcessorBuilder : AbstractProcessorBuilder
{
    public override ProcessorBase Build()
    {
        var processor = new BuiltinProcessor
        {
            Name = name,
            Type = ProcessorType.Builtin
        };
        if (strategy != null)
            processor.SetProcessingStrategy(strategy);
        return processor;
    }
}
