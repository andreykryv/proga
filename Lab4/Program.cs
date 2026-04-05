using Spectre.Console;
using YourNamespace; 

Operator? op = null;
int taskNumber;

while (true)
{
    AnsiConsole.Clear();

    taskNumber = AnsiConsole.Prompt(
        new SelectionPrompt<int>()
            .Title("[bold yellow]Доступные операции:[/]")
            .AddChoices(1, 2, 3, 4, 5, 6, 7, 8)
            .UseConverter(n => n switch
            {
                1 => "Создать оператора",
                2 => "Показать информацию",
                3 => "Увеличить тариф",
                4 => "Уменьшить тариф",
                5 => "Добавить абонентов",
                6 => "Удалить абонентов",
                7 => "Подсчитать выручку",
                _ => "Выход"
            }));

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
                    Validation.Pause();
                    break;
                }
            }

            Console.Write("Введите название оператора: ");
            string name = Console.ReadLine() ?? "Оператор";

            Console.Write("Введите начальное число абонентов: ");
            int subscribers = Validation.ReadNonNegativeInteger();

            Console.Write("Введите стоимость тарифа (руб.): ");
            decimal cost = Validation.ReadPositiveDecimal();

            op = Operator.GetInstance();
            AnsiConsole.MarkupLine($"[green]✔ Оператор \"{op.OperatorName}\" успешно создан![/]");

            Validation.Pause();
            break;

        case 2:
            if (!Validation.CheckOperator(op)) break;

            AnsiConsole.Write(new Rule("[bold]Информация об операторе[/]"));
            AnsiConsole.MarkupLine($"[cyan]Название :[/] {op!.OperatorName}");
            AnsiConsole.MarkupLine($"[cyan]Абоненты :[/] {op.SubscriberCount}");
            AnsiConsole.MarkupLine($"[cyan]Тариф    :[/] {op.CurrentTariffCost} руб.");
            AnsiConsole.MarkupLine($"[cyan]Выручка  :[/] {op.CalculateRevenue()} руб.");

            Validation.Pause();
            break;

        case 3:
            if (!Validation.CheckOperator(op)) break;
            AnsiConsole.MarkupLine($"Текущий тариф: [cyan]{op!.CurrentTariffCost}[/] руб.");
            Console.Write("На сколько увеличить (руб.): ");
            decimal increase = Validation.ReadDecimal();
            try
            {
                op.TariffUp(increase);
                AnsiConsole.MarkupLine($"[green]✔ Новый тариф: {op.CurrentTariffCost} руб.[/]");
            }
            catch (ArgumentException ex)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: {Markup.Escape(ex.Message)}[/]");
            }
            Validation.Pause();
            break;

        case 4:
            if (!Validation.CheckOperator(op)) break;
            AnsiConsole.MarkupLine($"Текущий тариф: [cyan]{op!.CurrentTariffCost}[/] руб.");
            Console.Write("На сколько уменьшить (руб.): ");
            decimal decrease = Validation.ReadDecimal();
            try
            {
                op.TariffDown(decrease);
                AnsiConsole.MarkupLine($"[green]✔ Новый тариф: {op.CurrentTariffCost} руб.[/]");
            }
            catch (ArgumentException ex)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: {Markup.Escape(ex.Message)}[/]");
            }
            catch (InvalidOperationException ex)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: {Markup.Escape(ex.Message)}[/]");
            }
            Validation.Pause();
            break;

        case 5:
            if (!Validation.CheckOperator(op)) break;
            AnsiConsole.MarkupLine($"Текущее число абонентов: [cyan]{op!.SubscriberCount}[/]");
            Console.Write("Сколько добавить: ");
            int addCount = Validation.ReadInteger();
            try
            {
                op.AddSubscribers(addCount);
                AnsiConsole.MarkupLine($"[green]✔ Теперь абонентов: {op.SubscriberCount}[/]");
            }
            catch (ArgumentException ex)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: {Markup.Escape(ex.Message)}[/]");
            }
            Validation.Pause();
            break;

        case 6:
            if (!Validation.CheckOperator(op)) break;
            AnsiConsole.MarkupLine($"Текущее число абонентов: [cyan]{op!.SubscriberCount}[/]");
            Console.Write("Сколько удалить: ");
            int removeCount = Validation.ReadInteger();
            try
            {
                op.RemoveSubscribers(removeCount);
                AnsiConsole.MarkupLine($"[green]✔ Теперь абонентов: {op.SubscriberCount}[/]");
            }
            catch (ArgumentException ex)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: {Markup.Escape(ex.Message)}[/]");
            }
            Validation.Pause();
            break;

        case 7:
            if (!Validation.CheckOperator(op)) break;

            decimal revenue = op!.CalculateRevenue();
            AnsiConsole.Write(new Rule("[bold]Расчёт выручки[/]"));
            AnsiConsole.MarkupLine($"[cyan]Абоненты :[/] {op.SubscriberCount}");
            AnsiConsole.MarkupLine($"[cyan]Тариф    :[/] {op.CurrentTariffCost} руб.");
            AnsiConsole.MarkupLine($"[cyan]Формула  :[/] {op.SubscriberCount} × {op.CurrentTariffCost} = [bold green]{revenue}[/] руб.");

            Validation.Pause();
            break;

        case 8:
            AnsiConsole.MarkupLine("[grey]Программа завершена. До свидания![/]");
            return;

        default:
            AnsiConsole.MarkupLine("[red]Неверный пункт меню.[/]");
            Validation.Pause();
            break;
    }
}