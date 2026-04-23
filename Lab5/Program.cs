using Spectre.Console;

// Инициализация провайдера и тарифов
Provider ATS = new Provider("ATS");

Tariff basic = new Tariff("Базовый", TariffType.Basic, 300m, 2.5m);
ATS.AddTariff(basic);
Tariff standart = new Tariff("Стандартный", TariffType.Standard, 600m, 1.2m);
ATS.AddTariff(standart);
Tariff premium = new Tariff("Премиум", TariffType.Premium, 900m, 0.5m);
ATS.AddTariff(premium);
Tariff unlimited = new Tariff("Безграничный", TariffType.Unlimited, 1500m, 0.0m);
ATS.AddTariff(unlimited);

// Список клиентов для работы
List<Client> clients = new List<Client>();

// Главное меню программы
void ShowMainMenu()
{
    AnsiConsole.Clear();

    var panel = new Panel(@"
[bold yellow]╔══════════════════════════════════════════╗[/]
[bold yellow]║     СИСТЕМА УПРАВЛЕНИЯ ТАРИФАМИ ATS      ║[/]
[bold yellow]╚══════════════════════════════════════════╝[/]
")
    {
        Border = BoxBorder.None,
        Padding = new Padding(0, 0, 0, 1)
    };
    AnsiConsole.Write(panel);

    var menuOptions = new List<string>
    {
        "[bold green]Просмотреть все тарифы[/]",
        "[bold blue]Добавить нового клиента[/]",
        "[bold magenta]Просмотреть всех клиентов[/]",
        "[bold cyan]Добавить трафик клиенту[/]",
        "[bold yellow]Найти клиента с наибольшей оплатой[/]",
        "[bold green]Рассчитать суммарную прибыль[/]",
        "[bold red]Выход[/]"
    };

    var selectionPrompt = new SelectionPrompt<string>()
        .Title("[bold white]Выберите действие:[/]")
        .AddChoices(menuOptions);

    string selected = AnsiConsole.Prompt(selectionPrompt);
int choice = menuOptions.IndexOf(selected);
    ExecuteMenuChoice(choice);
}

void ExecuteMenuChoice(int choice)
{
    switch (choice)
    {
        case 0:
            ShowAllTariffs();
            break;
        case 1:
            AddNewClient();
            break;
        case 2:
            ShowAllClients();
            break;
        case 3:
            AddTrafficToClient();
            break;
        case 4:
            ShowGreatestClient();
            break;
        case 5:
            ShowSummaryProfit();
            break;
        case 6:
            ExitProgram();
            break;
    }
}

void ShowAllTariffs()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold underline]Список доступных тарифов:[/]\n");

    var table = new Table();
    table.AddColumn(new TableColumn("[bold]Название[/]").Centered());
    table.AddColumn(new TableColumn("[bold]Тип[/]").Centered());
    table.AddColumn(new TableColumn("[bold]Абон. плата (руб.)[/]").RightAligned());
    table.AddColumn(new TableColumn("[bold]Цена за МБ (руб.)[/]").RightAligned());

    foreach (var tariff in ATS.tariffs)
    {
        table.AddRow(
            tariff.Name,
            tariff.Type.ToString(),
            tariff.MonthlyFee.ToString("F2"),
            tariff.PricePerMb.ToString("F2")
        );
    }

    AnsiConsole.Write(table);
    AnsiConsole.WriteLine();
    ContinuePrompt();
    ShowMainMenu();
}

void AddNewClient()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold underline]Добавление нового клиента[/]\n");

    // Выбор тарифа
    var tariffNames = ATS.tariffs.Select(t => t.Name).ToList();
    int tariffIndex = InputValidator.GetMenuSelection(
        "[bold]Выберите тариф:[/]",
        tariffNames
    );
    Tariff selectedTariff = ATS.tariffs[tariffIndex];

    // Ввод данных клиента
    int id = InputValidator.GetIntInRange("Введите ID клиента: ", 1, int.MaxValue);
    string name = InputValidator.GetNonEmptyString("Введите имя клиента: ");

    try
    {
        Client newClient = new Client(id, name, selectedTariff);
        ATS.AddClient(newClient);
        clients.Add(newClient);

        AnsiConsole.MarkupLine($"\n[bold green]✓ Клиент '{name}' успешно добавлен![/]");
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"\n[bold red]✗ Ошибка: {ex.Message}[/]");
    }

    ContinuePrompt();
    ShowMainMenu();
}

void ShowAllClients()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold underline]Список клиентов:[/]\n");

    if (ATS.clients.Count == 0)
    {
        AnsiConsole.MarkupLine("[yellow]Список клиентов пуст.[/]");
    }
    else
    {
        var table = new Table();
        table.AddColumn(new TableColumn("[bold]ID[/]").Centered());
        table.AddColumn(new TableColumn("[bold]Имя[/]").LeftAligned());
        table.AddColumn(new TableColumn("[bold]Тариф[/]").LeftAligned());
        table.AddColumn(new TableColumn("[bold]Трафик (МБ)[/]").RightAligned());
        table.AddColumn(new TableColumn("[bold]Стоимость (руб.)[/]").RightAligned());

        foreach (var client in ATS.clients)
        {
            table.AddRow(
                client.Id.ToString(),
                client.Name,
                client.Tariff.Name,
                client.TrafficMb.ToString("F2"),
                client.CalculateCost().ToString("F2")
            );
        }

        AnsiConsole.Write(table);
    }

    AnsiConsole.WriteLine();
    ContinuePrompt();
    ShowMainMenu();
}

void AddTrafficToClient()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold underline]Добавление трафика клиенту[/]\n");

    if (ATS.clients.Count == 0)
    {
        AnsiConsole.MarkupLine("[yellow]Список клиентов пуст. Сначала добавьте клиентов.[/]");
        ContinuePrompt();
        ShowMainMenu();
        return;
    }

    // Выбор клиента
    var clientNames = ATS.clients.Select(c => $"{c.Id}. {c.Name} ({c.Tariff.Name})").ToList();
    int clientIndex = InputValidator.GetMenuSelection(
        "[bold]Выберите клиента:[/]",
        clientNames
    );
    Client selectedClient = ATS.clients[clientIndex];

    // Ввод количества трафика
    decimal traffic = InputValidator.GetNonNegativeDecimal("Введите количество трафика (МБ): ");

    try
    {
        selectedClient.AddTraffic(traffic);
        AnsiConsole.MarkupLine($"\n[bold green]✓ Добавлено {traffic} МБ трафика для клиента '{selectedClient.Name}'.[/]");
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"\n[bold red]✗ Ошибка: {ex.Message}[/]");
    }

    ContinuePrompt();
    ShowMainMenu();
}

void ShowGreatestClient()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold underline]Клиент с наибольшей оплатой[/]\n");

    try
    {
        Client greatest = ATS.GreatestClient();

        var panel = new Panel($@"
[bold]ID:[/] {greatest.Id}
[bold]Имя:[/] {greatest.Name}
[bold]Тариф:[/] {greatest.Tariff.Name}
[bold]Трафик:[/] {greatest.TrafficMb} МБ
[bold green]Стоимость услуг: {greatest.CalculateCost():F2} руб.[/]
")
        {
            Border = BoxBorder.Rounded,
            BorderStyle = new Style(Color.Green)
        };

        AnsiConsole.Write(panel);
    }
    catch (InvalidOperationException ex)
    {
        AnsiConsole.MarkupLine($"[bold red]✗ Ошибка: {ex.Message}[/]");
    }

    ContinuePrompt();
    ShowMainMenu();
}

void ShowSummaryProfit()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold underline]Суммарная прибыль[/]\n");

    try
    {
        decimal profit = ATS.SummaryProfit();

        var panel = new Panel($@"
[bold]Общая сумма клиентов:[/] {ATS.clients.Count}
[bold green]Суммарная прибыль: {profit:F2} руб.[/]
")
        {
            Border = BoxBorder.Rounded,
            BorderStyle = new Style(Color.Green)
        };

        AnsiConsole.Write(panel);
    }
    catch (ArgumentException ex)
    {
        AnsiConsole.MarkupLine($"[bold red]✗ Ошибка: {ex.Message}[/]");
    }

    ContinuePrompt();
    ShowMainMenu();
}

void ExitProgram()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold yellow]Спасибо за использование системы ATS! До свидания![/]");
    Environment.Exit(0);
}

void ContinuePrompt()
{
    AnsiConsole.WriteLine();
    AnsiConsole.Markup("[dim]Нажмите Enter для продолжения...[/]");
    Console.ReadLine();
}

// Запуск программы
ShowMainMenu();