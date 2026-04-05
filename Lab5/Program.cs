// See https://aka.ms/new-console-template for more information

Provider ATS = new Provider("ATS");





Tariff basic = new Tariff("Базовый", TariffType.Basic, 300m, 2.5m);
ATS.AddTariff(basic);
Tariff standart = new Tariff("Стандартный", TariffType.Standard, 600m, 1.2m);
ATS.AddTariff(standart);
Tariff premium = new Tariff("Премиум", TariffType.Premium, 900m, 0.5m);
ATS.AddTariff(premium);
Tariff unlimited = new Tariff("Безграничный", TariffType.Unlimited, 1500m,0.0m);
ATS.AddTariff(unlimited);
Client a = new Client(1, "клиент 1", basic);
ATS.AddClient(a);
Client b = new Client(2, "клиент 2", standart);
ATS.AddClient(b);
Client c = new Client(3, "клиент 3", premium);
ATS.AddClient(c);

a.AddTraffic(1000);
b.AddTraffic(2000);
c.AddTraffic(3000);


Console.WriteLine(basic.ToString());
Console.WriteLine(standart.ToString());
Console.WriteLine(premium.ToString());
Console.WriteLine(unlimited.ToString());

Console.WriteLine(a.ToString());
Console.WriteLine(b.ToString());
Console.WriteLine(c.ToString());
try
{
    Console.WriteLine($"Клиент, заплативший наибольшую стоимость за услуги {ATS.GreatestClient()}") ;
}
catch (InvalidOperationException ex)
{
    
     Console.WriteLine($"Ошибка: {ex.Message}");
}
try
{
    Console.WriteLine($"Суммарный профит: {ATS.SummaryProfit()}");


}
catch (ArgumentException ex)
{
    
    Console.WriteLine($"Ошибка: {ex.Message}");
}



















