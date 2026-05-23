/// <summary>
/// Директор — создаёт готовые конфигурации процессоров через построители.
/// </summary>
static class Director
{
    /// <summary>Настольный процессор-шинковщик (нарезка тонкими ломтиками)</summary>
    public static ProcessorBase GetChoppingTable(string name, AbstractProcessorBuilder builder)
    {
        return builder
            .SetName(name)
            .SetStrategy(new ChoppingStrategy())
            .Build();
    }

    /// <summary>Ручной процессор-измельчитель (перемол в крошку)</summary>
    public static ProcessorBase GetGrindingHand(string name, AbstractProcessorBuilder builder)
    {
        return builder
            .SetName(name)
            .SetStrategy(new GrindingStrategy())
            .Build();
    }

    /// <summary>Встроенный процессор с функцией мясорубки</summary>
    public static ProcessorBase GetMeatGrinderBuiltin(string name, AbstractProcessorBuilder builder)
    {
        return builder
            .SetName(name)
            .SetStrategy(new MeatGrinderStrategy())
            .Build();
    }

    /// <summary>Настольный процессор-нарезчик кубиками</summary>
    public static ProcessorBase GetSlicingTable(string name, AbstractProcessorBuilder builder)
    {
        return builder
            .SetName(name)
            .SetStrategy(new SlicingStrategy())
            .Build();
    }

    /// <summary>Встроенный процессор-измельчитель</summary>
    public static ProcessorBase GetGrindingBuiltin(string name, AbstractProcessorBuilder builder)
    {
        return builder
            .SetName(name)
            .SetStrategy(new GrindingStrategy())
            .Build();
    }

    /// <summary>Базовый процессор без режима обработки</summary>
    public static ProcessorBase GetBasicProcessor(string name, AbstractProcessorBuilder builder)
    {
        return builder
            .SetName(name)
            .Build();
    }
}
