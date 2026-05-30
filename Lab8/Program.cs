using Spectre.Console;

// ===================================================
// Лабораторная работа №8 — Полиморфизм
// Интерактивный режим с использованием Spectre.Console
// ===================================================

// ---------- 1. Предопределённые тарифы ----------
var basic = new Tariff("Базовый", TariffType.Basic, 5.00m, 0.01m);
var standard = new Tariff("Стандарт", TariffType.Standard, 10.00m, 0.008m);
var premium = new Tariff("Премиум", TariffType.Premium, 20.00m, 0.005m);
var tariffs = new List<Tariff> { basic, standard, premium };

// ---------- 2. Создаём оператора и несколько начальных клиентов (для демонстрации) ----------
var isp = new Operator("ByNet ISP");

// Начальные демо-клиенты (можно удалить, но оставим для удобства)
var alice = new Client(1, "Алиса", basic);
var bob = new Client(2, "Боб", standard);
var carol = new Client(3, "Кэрол", premium);
carol.SetStrategy(new DiscountStrategy(0.20m));
carol.AddTraffic(3000);
alice.AddTraffic(500);
bob.AddTraffic(1200);
carol.AddTraffic(3000);
isp.AddClient(alice);
isp.AddClient(bob);
isp.AddClient(carol);

// ---------- 3. Основной цикл меню ----------
bool exit = false;
while (!exit)
{
    Console.Clear();
    AnsiConsole.Write(new Rule("[yellow]Интернет-оператор \"ByNet ISP\"[/]").RuleStyle("green"));
    
    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Главное меню")
            .PageSize(10)
            .AddChoices(new[]
            {
                "📋 Показать всех клиентов",
                "➕ Добавить нового клиента",
                "📊 Добавить трафик клиенту",
                "⚙️ Сменить стратегию расчёта клиенту",
                "💰 Показать выручку оператора",
                "🚪 Выход"
            }));

    switch (choice)
    {
        case "📋 Показать всех клиентов":
            ShowAllClients(isp.clients);
            break;
        case "➕ Добавить нового клиента":
            AddNewClient(isp, tariffs);
            break;
        case "📊 Добавить трафик клиенту":
            AddTrafficToClient(isp.clients);
            break;
        case "⚙️ Сменить стратегию расчёта клиенту":
            ChangeStrategyForClient(isp.clients);
            break;
        case "💰 Показать выручку оператора":
            ShowProfit(isp);
            break;
        case "🚪 Выход":
            exit = true;
            continue;
    }

    if (!exit)
    {
        AnsiConsole.MarkupLine("\n[grey]Нажмите любую клавишу для продолжения...[/]");
        Console.ReadKey(true);
    }
}


void ShowAllClients(List<Client> clients)
{
    if (!clients.Any())
    {
        AnsiConsole.MarkupLine("[red]Нет клиентов.[/]");
        return;
    }

    var table = new Table();
    table.AddColumn("ID");
    table.AddColumn("Имя");
    table.AddColumn("Тариф");
    table.AddColumn("Трафик (МБ)");
    table.AddColumn("Стоимость (руб)");
    table.AddColumn("Скидка");

    foreach (var c in clients)
    {
        string discountInfo = c.CurrentDiscount.HasValue ? $"{c.CurrentDiscount.Value:P0}" : "—";
        table.AddRow(
            c.Id.ToString(),
            c.Name,
            c.Tariff.Name,
            c.TrafficMb.ToString("F2"),
            c.CalculateCost().ToString("F2"),
            discountInfo
        );
    }
    AnsiConsole.Write(table);
}

void AddNewClient(Operator op, List<Tariff> availableTariffs)
{
    try
    {
        // Уникальный ID (максимальный существующий + 1)
        int newId = op.clients.Any() ? op.clients.Max(c => c.Id) + 1 : 1;
        AnsiConsole.MarkupLine($"[yellow]Новому клиенту будет автоматически присвоен ID = {newId}[/]");

        string name = InputHelper.GetString("Введите имя клиента:", 
            s => !string.IsNullOrWhiteSpace(s), "Имя не может быть пустым.");

        var tariff = InputHelper.GetChoice("Выберите тариф:", availableTariffs, t => $"{t.Name} — {t.MonthlyFee} руб./мес + {t.PricePerMb} руб./МБ");

        bool hasDiscount = AnsiConsole.Confirm("Предоставить скидку?", false);
        if (!hasDiscount)
        {
            var client = new Client(newId, name, tariff);
            op.AddClient(client);
            AnsiConsole.MarkupLine($"[green]Клиент {name} (ID {newId}) добавлен.[/]");
        }
        else
        {
            decimal discount = InputHelper.GetDiscount();
           var client = new Client(newId, name, tariff);
client.SetStrategy(new DiscountStrategy(discount));
            op.AddClient(client);
            AnsiConsole.MarkupLine($"[green]Клиент {name} (ID {newId}) со скидкой {discount:P0} добавлен.[/]");
        }
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[red]Ошибка при добавлении клиента: {ex.Message}[/]");
    }
}

void AddTrafficToClient(List<Client> clients)
{
    if (!clients.Any())
    {
        AnsiConsole.MarkupLine("[red]Нет клиентов для добавления трафика.[/]");
        return;
    }

    try
    {
        var client = InputHelper.GetClientById(clients);
        decimal mb = InputHelper.GetTraffic();
        client.AddTraffic(mb);
        AnsiConsole.MarkupLine($"[green]Клиенту {client.Name} добавлено {mb} МБ. Теперь трафик: {client.TrafficMb} МБ[/]");
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[red]Ошибка: {ex.Message}[/]");
    }
}

void ChangeStrategyForClient(List<Client> clients)
{
    if (!clients.Any())
    {
        AnsiConsole.MarkupLine("[red]Нет клиентов.[/]");
        return;
    }

    try
    {
        var client = InputHelper.GetClientById(clients);
        var strategyType = InputHelper.GetChoice("Выберите стратегию расчёта:", new[]
        {
            "Стандартная (абон. плата + трафик)",
            "Ночной тариф (трафик со скидкой 50%)",
            "Скидка (фиксированный процент)"
        });

        ICostCalculationStrategy? strategy = null;
        switch (strategyType)
        {
            case "Стандартная (абон. плата + трафик)":
                strategy = new StandardStrategy();
                break;
            case "Ночной тариф (трафик со скидкой 50%)":
                strategy = new NightTariffStrategy();
                break;
            case "Скидка (фиксированный процент)":
                decimal discount = InputHelper.GetDiscount("Введите процент скидки (0..1):");
                strategy = new DiscountStrategy(discount);
                break;
        }

        if (strategy != null)
        {
            client.SetStrategy(strategy);
            AnsiConsole.MarkupLine($"[green]Стратегия для {client.Name} изменена.[/]");
        }
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[red]Ошибка: {ex.Message}[/]");
    }
}

void ShowProfit(Operator op)
{
    decimal profit = op.SummaryProfit();
    var table = new Table();
    table.AddColumn("Оператор");
    table.AddColumn("Количество клиентов");
    table.AddColumn("Суммарная выручка (руб)");
    table.AddRow(op.Name, op.clients.Count.ToString(), profit.ToString("F2"));
    AnsiConsole.Write(table);
}