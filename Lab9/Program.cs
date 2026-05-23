// =========================================================
//  Лабораторная работа №9 — Кухонный процессор
//  Паттерны: Bridge + Builder
//  Множественное наследование через интерфейсы
// =========================================================

// ----- строители -----
var tableBuilder   = new TableProcessorBuilder();
var handBuilder    = new HandProcessorBuilder();
var builtinBuilder = new BuiltinProcessorBuilder();

// ----- создаём коллекцию разнотипных процессоров через Director -----
var processors = new List<ProcessorBase>
{
    Director.GetChoppingTable   ("Bosch MultiTalent 8",  tableBuilder),
    Director.GetSlicingTable    ("Philips HR7778",        tableBuilder),
    Director.GetGrindingHand    ("Braun MQ9135X",         handBuilder),
    Director.GetBasicProcessor  ("IKEA SMAKSAM",          handBuilder),
    Director.GetMeatGrinderBuiltin("KitchenAid Artisan",  builtinBuilder),
    Director.GetGrindingBuiltin ("Miele XL Chef",         builtinBuilder),
};

// ----- обходим коллекцию и вызываем все доступные методы -----
foreach (var processor in processors)
{
    Console.WriteLine(new string('═', 55));

    // GetInfo — переопределён в каждом классе по-своему
    processor.GetInfo();

    // Process — Bridge: делегируется конкретной стратегии
    processor.Process();

    // Проверяем и вызываем дополнительные интерфейсы
    if (processor is IMixer mixer)
        mixer.Mix();

    if (processor is IBlender blender)
        blender.Blend();

    if (processor is IDoughMixer doughMixer)
        doughMixer.MixDough();

    if (processor is IJuicer juicer)
        juicer.ExtractJuice();
}

Console.WriteLine(new string('═', 55));
