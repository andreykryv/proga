/// <summary>
/// Строитель ручного (погружного) процессора
/// </summary>
class HandProcessorBuilder : AbstractProcessorBuilder
{
    public override ProcessorBase Build()
    {
        var processor = new HandProcessor
        {
            Name = name,
            Type = ProcessorType.Handheld
        };
        if (strategy != null)
            processor.SetProcessingStrategy(strategy);
        return processor;
    }
}
