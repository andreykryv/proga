using Spectre.Console;

/// <summary>
/// Класс для интерактивного создания процессоров через консоль (Spectre.Console)
/// </summary>
internal static class InteractiveProcessorBuilder
{
    /// <summary>
    /// Создать процессор на основе ввода пользователя
    /// </summary>
    public static ProcessorBase CreateProcessorInteractively()
    {
        // 1. Выбор типа процессора
        var processorType = AnsiConsole.Prompt(
            new SelectionPrompt<ProcessorType>()
                .Title("[yellow]Выберите тип процессора:[/]")
                .AddChoices(ProcessorType.Desktop, ProcessorType.Handheld, ProcessorType.Builtin)
                .UseConverter(t => t switch
                {
                    ProcessorType.Desktop => "Настольный",
                    ProcessorType.Handheld => "Ручной (погружной)",
                    ProcessorType.Builtin => "Встроенный",
                    _ => t.ToString()
                }));

        // 2. Выбор стратегии (можно пропустить)
        var strategyOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[yellow]Выберите режим обработки:[/]")
                .AddChoices("Шинкование", "Измельчение", "Мясорубка", "Нарезка кубиками", "Без стратегии")
                .UseConverter(o => o));

        IProcessingStrategy? strategy = strategyOption switch
        {
            "Шинкование" => new ChoppingStrategy(),
            "Измельчение" => new GrindingStrategy(),
            "Мясорубка" => new MeatGrinderStrategy(),
            "Нарезка кубиками" => new SlicingStrategy(),
            _ => null
        };

        // 3. Ввод имени с валидацией (пустая строка не допускается)
        string name = AnsiConsole.Prompt(
            new TextPrompt<string>("[green]Введите имя процессора:[/]")
                .Validate(input =>
                {
                    if (string.IsNullOrWhiteSpace(input))
                        return ValidationResult.Error("[red]Имя не может быть пустым![/]");
                    if (input.Length < 2)
                        return ValidationResult.Error("[red]Имя должно содержать хотя бы 2 символа.[/]");
                    return ValidationResult.Success();
                }));

        // 4. Получаем нужного строителя
        AbstractProcessorBuilder builder = GetBuilderForType(processorType);

        // 5. Строим процессор
        if (strategy != null)
            builder.SetName(name).SetStrategy(strategy);
        else
            builder.SetName(name);

        var processor = builder.Build();

        AnsiConsole.MarkupLine("[green]✓ Процессор успешно создан![/]");
        return processor;
    }

    private static AbstractProcessorBuilder GetBuilderForType(ProcessorType type)
    {
        return type switch
        {
            ProcessorType.Desktop => new TableProcessorBuilder(),
            ProcessorType.Handheld => new HandProcessorBuilder(),
            ProcessorType.Builtin => new BuiltinProcessorBuilder(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), "Неизвестный тип процессора")
        };
    }

    /// <summary>
    /// Демонстрация работы процессора (вывод информации + вызов Process)
    /// </summary>
    public static void DemonstrateProcessor(ProcessorBase processor)
    {
        AnsiConsole.Write(new Rule($"[yellow]Процессор: {processor.Name}[/]"));
        processor.GetInfo();
        processor.Process();
        
        // Дополнительные интерфейсы
        if (processor is IMixer mixer) mixer.Mix();
        if (processor is IBlender blender) blender.Blend();
        if (processor is IDoughMixer doughMixer) doughMixer.MixDough();
        if (processor is IJuicer juicer) juicer.ExtractJuice();
    }
}