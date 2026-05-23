using Spectre.Console;

// =========================================================
//  Лабораторная работа №9 — Кухонный процессор
//  Паттерны: Bridge + Builder + Spectre.Console
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

// ----- выводим предопределённые процессоры -----
AnsiConsole.Write(new Rule("[yellow]Предопределённые процессоры[/]"));
foreach (var processor in processors)
{
    InteractiveProcessorBuilder.DemonstrateProcessor(processor);
    Console.WriteLine();
}

// ----- интерактивное создание пользовательских процессоров -----
AnsiConsole.Write(new Rule("[green]Интерактивное создание процессоров[/]"));

bool createAnother = true;
while (createAnother)
{
    Console.WriteLine();
    var userProcessor = InteractiveProcessorBuilder.CreateProcessorInteractively();
    InteractiveProcessorBuilder.DemonstrateProcessor(userProcessor);
    
    createAnother = AnsiConsole.Confirm("[yellow]Создать ещё один процессор?[/]");
}

AnsiConsole.MarkupLine("[bold green]Работа программы завершена.[/]");