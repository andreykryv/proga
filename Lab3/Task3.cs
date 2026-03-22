using System.Globalization;

class Task3
{
    public static void Run()
    {while (true)
    {
        DateService service = new DateService();

        Console.WriteLine($"Текущая дата: {DateTime.Today:dd.MM.yyyy}");

        // Ввод даты для GetDay
        Console.Write("\nВведите дату (дд.мм.гггг) для определения дня недели: ");
        string inputDate = Console.ReadLine() ?? "";
        string dayOfWeek = service.GetDay(inputDate);
        Console.WriteLine($"День недели: {dayOfWeek}");

        // Ввод даты для GetDaysSpan
        Console.Write("\nВведите дату (дд.мм.гггг) для подсчёта разницы в днях: ");
        string inputSpanDate = Console.ReadLine() ?? "";

        if (DateTime.TryParseExact(inputSpanDate, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parsed))
        {
            int days = service.GetDaysSpan(parsed.Day, parsed.Month, parsed.Year);
            Console.WriteLine($"Количество дней между сегодня и {inputSpanDate}: {days}");
        }
        else
        {
            Console.WriteLine("Ошибка: неверный формат даты. Используйте дд.мм.гггг");
        }
         Console.WriteLine("Выбирете,что делать дальше: ");
    Console.WriteLine("1)Продолжить вычисления в заднии 2");
    Console.WriteLine("2)Завершить вычисления в задании 2");
    string? input;
   int continueOrNot;
   
    while (true)
    {
        
    input = Console.ReadLine();
  if (int.TryParse(input, out continueOrNot))
{ 
    if (continueOrNot == 2) { break; }
    else if (continueOrNot == 1) { break; }
    else { Console.WriteLine("Выберите корректный номер действия!"); }
}
else
{
    Console.WriteLine("Выберите корректный номер действия!");
}
  
    }
    if (continueOrNot == 2)
    {
        break;
    }
    }
        

      
    }
}