using Spectre.Console;

int taskNumber;

while (true)
{
    AnsiConsole.Clear();
    
    taskNumber = AnsiConsole.Prompt(
        new SelectionPrompt<int>()
            .Title("[bold yellow]Доступны задания:[/]")
            .AddChoices(1, 2, 3)
            .UseConverter(n => n == 1 
                ? "Задание 1 — Проверка делимости" 
                : (n == 2 ? "Задание 2 — Проверка принадлежности точки к области"
                : "Завершение работы."))
    );



switch (taskNumber)
{
    case 1: Task1.Run();
     break; 
    case 2: Task2.Run();
     break;
    case 3: Console.WriteLine("Программа завершена.");
     Environment.Exit(0);
     break;
     
}
}