// ===================================================
// Лабораторная работа №8 — Полиморфизм
// Предметная область: Интернет-оператор
// ===================================================

// ---------- 1. Тарифы ----------
var basic   = new Tariff("Базовый",    TariffType.Basic,    5.00m,  0.01m);
var standard = new Tariff("Стандарт",  TariffType.Standard, 10.00m, 0.008m);
var premium  = new Tariff("Премиум",   TariffType.Premium,  20.00m, 0.005m);

// ---------- 2. Клиенты ----------
var alice = new Client(1, "Алиса",    basic);
var bob   = new Client(2, "Боб",      standard);
var carol = new DiscountClient(3, "Кэрол", premium, 0.20m);   // скидка 20%
var dave  = new DiscountClient(4, "Дейв",  standard, 0.10m);  // скидка 10%

alice.AddTraffic(500m);
bob.AddTraffic(1200m);
carol.AddTraffic(3000m);
dave.AddTraffic(800m);

// ---------- 3. Оператор ----------
var isp = new Operator("ByNet ISP");
isp.AddClient(alice);
isp.AddClient(bob);
isp.AddClient(carol);
isp.AddClient(dave);

// ---------- 4. IDisplayable — вызов метода через интерфейсную ссылку ----------
Console.WriteLine("=== Информация о клиентах (через IDisplayable) ===");
foreach (Client c in isp.clients)
{
    IDisplayable displayable = c;          // интерфейсная ссылка
    Console.WriteLine(displayable.GetInfo());
}

// ---------- 5. Полиморфизм CalculateCost ----------
Console.WriteLine("\n=== Стоимость услуг (полиморфный CalculateCost) ===");
foreach (Client c in isp.clients)
    Console.WriteLine($"  {c.Name,-8}: {c.CalculateCost(),8:F2} руб.");

Console.WriteLine($"\n  Суммарная выручка оператора: {isp.SummaryProfit():F2} руб.");

// ---------- 6. Strategy pattern — смена алгоритма расчёта в runtime ----------
Console.WriteLine("\n=== Strategy pattern: ночной тариф для Алисы ===");
Console.WriteLine($"  Алиса (стандарт): {alice.CalculateCost():F2} руб.");
alice.SetStrategy(new NightTariffStrategy());
Console.WriteLine($"  Алиса (ночной  ): {alice.CalculateCost():F2} руб.");
alice.SetStrategy(new DiscountStrategy(0.15m));
Console.WriteLine($"  Алиса (скидка 15%): {alice.CalculateCost():F2} руб.");
alice.SetStrategy(new StandardStrategy());          // вернуть стандарт
Console.WriteLine($"  Алиса (стандарт снова): {alice.CalculateCost():F2} руб.");

// ---------- 7. IDiscountable — явная реализация (кастинг) ----------
Console.WriteLine("\n=== IDiscountable: доступ через кастинг ===");
foreach (Client c in isp.clients)
{
    if (c is IDiscountable disc)              // проверка и кастинг
    {
        decimal before = c.Tariff.MonthlyFee + c.TrafficMb * c.Tariff.PricePerMb;
        decimal after  = disc.ApplyDiscount(before);
        Console.WriteLine($"  {c.Name}: скидка {disc.Discount:P0} | до: {before:F2} → после: {after:F2} руб.");
    }
}

// ---------- 8. IBillable — интерфейсная ссылка на список ----------
Console.WriteLine("\n=== IBillable: суммируем через интерфейс ===");
List<IBillable> billables = new List<IBillable>(isp.clients);  // неявное приведение
decimal sum = 0;
foreach (IBillable b in billables)
{
    Console.WriteLine($"  Счёт: {b.CalculateCost(),8:F2} руб." +
                      $"  (абон. {b.MonthlyFee:F2} + трафик {b.TrafficMb} МБ × {b.PricePerMb})");
    sum += b.CalculateCost();
}
Console.WriteLine($"\n  Итого по IBillable: {sum:F2} руб.");

// ---------- 9. Демонстрация полиморфизма через базовый тип ----------
Console.WriteLine("\n=== Полиморфизм: Client[] содержит и Client, и DiscountClient ===");
Client[] mixed = { alice, carol };
foreach (Client c in mixed)
{
    Console.WriteLine($"  [{c.GetType().Name}] {c.Name}: {c.CalculateCost():F2} руб.");
}