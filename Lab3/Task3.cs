#nullable enable
using System;
using System.Globalization;

class Task3
{
    public static void Run()
    {
        DateService service = new DateService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Текущая дата: {DateTime.Today:dd.MM.yyyy}");

        
        string inputDate;
        while (true)
            {
                Console.Write("\nВведите дату (дд.мм.гггг) для определения дня недели: ");
                inputDate = Console.ReadLine()?.Trim() ?? "";

                string? validationError = service.ValidateDate(inputDate, detailed: true);
                if (validationError == null)
                {
                string dayOfWeek = service.GetDay(inputDate);
                Console.WriteLine($"День недели: {dayOfWeek}");
                break;
                }
                Console.WriteLine(validationError);
                System.Threading.Thread.Sleep(1500); 
            }

           
        DateTime parsedDate;
        while (true)
            {
                Console.Write("\nВведите дату (дд.мм.гггг) для подсчёта разницы в днях: ");
                string inputSpanDate = Console.ReadLine()?.Trim() ?? "";

                if (DateTime.TryParseExact(inputSpanDate, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out parsedDate))
                {
                int days = service.GetDaysSpan(parsedDate.Day, parsedDate.Month, parsedDate.Year);
                Console.WriteLine($"Количество дней между сегодня и {inputSpanDate}: {days}");
                break;
                }

                string? specificError = service.ValidateDate(inputSpanDate, detailed: true);
                if (specificError != null)
                    Console.WriteLine(specificError);
                else
                    Console.WriteLine("Ошибка: неверный формат даты. Используйте дд.мм.гггг");

                System.Threading.Thread.Sleep(1500);
            }

         
        int continueOrNot;
        while (true)
            {
                Console.WriteLine("\nВыберите, что делать дальше:");
                Console.WriteLine("1) Продолжить вычисления в задании 3");
                Console.WriteLine("2) Завершить вычисления в задании 3");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out continueOrNot) && (continueOrNot == 1 || continueOrNot == 2))
                break;

                Console.WriteLine("Выберите корректный номер действия (1 или 2)!");
            }

            if (continueOrNot == 2)
            break;
       
        }
 }}