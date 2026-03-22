// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Numerics;
using System.Runtime.CompilerServices;
using Spectre.Console;



Operator? op = null;
int taskNumber;




    
    

while (true)
{
    AnsiConsole.Clear();
    
    taskNumber = AnsiConsole.Prompt(
        new SelectionPrompt<int>()
            .Title("[bold yellow]Доступные операции:[/]")
            .AddChoices(1, 2,3,4,5,6,7,8)
            .UseConverter(n => n == 1 
                ? "Создать оператора" 
                : (n == 2 ? "Показать информацию"
                : n == 3 ? "Увеличить тариф"
                : n == 4 ? "Уменьшить тариф"
                : n == 5 ? "Добавить абонентов"
                : n == 6 ? "Удалить абонентов"
                : n == 7 ? "Подсчитать выручку"

                :"Выход"))
    );



switch (taskNumber)
{
    case 1:
            if (op != null)
            {
                AnsiConsole.MarkupLine("[yellow]Оператор уже создан (Singleton).[/]");
                Console.Write("Хотите сбросить и создать заново? (д/н): ");
                string? reset = Console.ReadLine();
                if (reset?.ToLower() == "д")
                {
                    Operator.ResetInstance();
                    op = null;
                    AnsiConsole.MarkupLine("[green]Singleton сброшен.[/]\n");
                }
                else
                {
                    Help.Pause();
                    break;
                }
            }

            Console.Write("Введите название оператора: ");
            string name = Console.ReadLine() ?? "Оператор";

            Console.Write("Введите начальное число абонентов: ");
            int subscribers = Help.ReadNonNegativeInteger();

            Console.Write("Введите стоимость тарифа (руб.): ");
            decimal cost = Help.ReadPositiveDecimal();

            op = Operator.GetInstance(name, subscribers, cost);
            AnsiConsole.MarkupLine($"[green]✔ Оператор \"{op.OperatorName}\" успешно создан![/]");

            Help.Pause();
            break;

        // Показать информацию
        case 2:
            if (!Help.CheckOperator(op)) break;

            AnsiConsole.Write(new Rule("[bold]Информация об операторе[/]"));
            AnsiConsole.MarkupLine($"[cyan]Название :[/] {op!.OperatorName}");
            AnsiConsole.MarkupLine($"[cyan]Абоненты :[/] {op.SubscriberCount}");
            AnsiConsole.MarkupLine($"[cyan]Тариф    :[/] {op.CurrentTariffCost} руб.");
            AnsiConsole.MarkupLine($"[cyan]Выручка  :[/] {op.CalculateRevenue()} руб.");

            Help.Pause();
            break;

        //  Увеличить тариф 
        case 3:
            if (!Help.CheckOperator(op)) break;

            AnsiConsole.MarkupLine($"Текущий тариф: [cyan]{op!.CurrentTariffCost}[/] руб.");
            Console.Write("На сколько увеличить (руб.): ");
            decimal increase = Help.ReadDecimal();

            if (increase <= 0)
                AnsiConsole.MarkupLine("[red]Ошибка: сумма должна быть положительной.[/]");
            else
            {
                op.TariffUp(increase);
                AnsiConsole.MarkupLine($"[green]✔ Новый тариф: {op.CurrentTariffCost} руб.[/]");
            }

            Help.Pause();
            break;

        // Уменьшить тариф
        case 4:
            if (!Help.CheckOperator(op)) break;

            AnsiConsole.MarkupLine($"Текущий тариф: [cyan]{op!.CurrentTariffCost}[/] руб.");
            Console.Write("На сколько уменьшить (руб.): ");
            decimal decrease = Help.ReadDecimal();

            if (decrease <= 0)
                AnsiConsole.MarkupLine("[red]Ошибка: сумма должна быть положительной.[/]");
            else if (op.CurrentTariffCost - decrease < 0)
                AnsiConsole.MarkupLine("[red]Ошибка: тариф не может стать отрицательным.[/]");
            else
            {
                op.TariffDown(decrease);
                AnsiConsole.MarkupLine($"[green]✔ Новый тариф: {op.CurrentTariffCost} руб.[/]");
            }

            Help.Pause();
            break;

        //Добавить абонентов
        case 5:
            if (!Help.CheckOperator(op)) break;

            AnsiConsole.MarkupLine($"Текущее число абонентов: [cyan]{op!.SubscriberCount}[/]");
            Console.Write("Сколько добавить: ");
            int addCount = Help.ReadInteger();

            if (addCount <= 0)
                AnsiConsole.MarkupLine("[red]Ошибка: число должно быть положительным.[/]");
            else
            {
                op.AddSubscribers(addCount);
                AnsiConsole.MarkupLine($"[green]✔ Теперь абонентов: {op.SubscriberCount}[/]");
            }

            Help.Pause();
            break;

        // Удалить абонентов 
        case 6:
            if (!Help.CheckOperator(op)) break;

            AnsiConsole.MarkupLine($"Текущее число абонентов: [cyan]{op!.SubscriberCount}[/]");
            Console.Write("Сколько удалить: ");
            int removeCount = Help.ReadInteger();

            if (removeCount <= 0)
                AnsiConsole.MarkupLine("[red]Ошибка: число должно быть положительным.[/]");
            else if (removeCount > op.SubscriberCount)
                AnsiConsole.MarkupLine("[red]Ошибка: нельзя удалить больше абонентов, чем есть.[/]");
            else
            {
                op.RemoveSubscribers(removeCount);
                AnsiConsole.MarkupLine($"[green]✔ Теперь абонентов: {op.SubscriberCount}[/]");
            }

            Help.Pause();
            break;

        // Подсчитать выручку 
        case 7:
            if (!Help.CheckOperator(op)) break;

            decimal revenue = op!.CalculateRevenue();
            AnsiConsole.Write(new Rule("[bold]Расчёт выручки[/]"));
            AnsiConsole.MarkupLine($"[cyan]Абоненты :[/] {op.SubscriberCount}");
            AnsiConsole.MarkupLine($"[cyan]Тариф    :[/] {op.CurrentTariffCost} руб.");
            AnsiConsole.MarkupLine($"[cyan]Формула  :[/] {op.SubscriberCount} × {op.CurrentTariffCost} = [bold green]{revenue}[/] руб.");

            Help.Pause();
            break;

       

       
        case 8:
            AnsiConsole.MarkupLine("[grey]Программа завершена. До свидания![/]");
            return;

        default:
            AnsiConsole.MarkupLine("[red]Неверный пункт меню.[/]");
            Help.Pause();
            break;
    }
}

      

