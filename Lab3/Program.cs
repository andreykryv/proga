// See https://aka.ms/new-console-template for more information

using Spectre.Console;

int taskNumber;

while (true)
{
    AnsiConsole.Clear();
    
    taskNumber = AnsiConsole.Prompt(
        new SelectionPrompt<int>()
            .Title("[bold yellow]Доступны задания:[/]")
            .AddChoices(1, 2, 3,4)
            .UseConverter(n => n == 1 
                ? "Задание 1 — проверка на двухзначное число и свап чисел if true" 
                : (n == 2 ? "Задание 2 - вычисление с разными ветками"
                : n == 3 ? "Задание 3 - время"
                :"Завершение работы"))
    );



switch (taskNumber)
{
    case 1: Task1.Run();
     break; 
    case 2: Task2.Run();
     break;
    case 3: Task3.Run();
     break;
    case 4: Console.WriteLine("Программа завершена.");
     Environment.Exit(0);
     break;
     
}
}