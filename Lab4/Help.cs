using Spectre.Console;

class Help
{
   
    public static void Pause()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[grey]Нажмите Enter для продолжения...[/]");
        Console.ReadLine();
    }

    //  Проверка наличия оператора 
    public static bool CheckOperator(Operator? op)
    {
        if (op == null)
        {
            AnsiConsole.MarkupLine("[red]Ошибка: сначала создайте оператора (пункт 1).[/]");
            Pause();
            return false;
        }
        return true;
    }

    //  Чтение строки (не пустой) 
    public static string ReadString()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();
            AnsiConsole.Markup("[red]Ошибка: строка не может быть пустой. Повторите ввод: [/]");
        }
    }

    //  Чтение целого числа (любого) 
    public static int ReadInteger()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Ошибка: поле не может быть пустым. Повторите ввод: ");
                continue;
            }
            if (int.TryParse(input, out int result))
                return result;
            Console.Write("Ошибка: введите целое число (например 100): ");
        }
    }

    //  Чтение целого числа с ограничением min..max 
    public static int ReadInteger(int min, int max)
    {
        while (true)
        {
            int value = ReadInteger();
            if (value >= min && value <= max)
                return value;
            Console.Write($"Ошибка: введите число от {min} до {max}: ");
        }
    }

    //  Чтение положительного целого 
    public static int ReadPositiveInteger()
    {
        while (true)
        {
            int value = ReadInteger();
            if (value > 0)
                return value;
            Console.Write("Ошибка: число должно быть больше нуля. Повторите ввод: ");
        }
    }

    //  Чтение неотрицательного целого 
    public static int ReadNonNegativeInteger()
    {
        while (true)
        {
            int value = ReadInteger();
            if (value >= 0)
                return value;
            Console.Write("Ошибка: число не может быть отрицательным. Повторите ввод: ");
        }
    }

    //  Чтение дробного числа (любого) 
    public static decimal ReadDecimal()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Ошибка: поле не может быть пустым. Повторите ввод: ");
                continue;
            }
            if (decimal.TryParse(input, out decimal result))
                return result;
            Console.Write("Ошибка: введите число (например 99,50): ");
        }
    }

    //  Чтение дробного числа с ограничением min..max 
    public static decimal ReadDecimal(decimal min, decimal max)
    {
        while (true)
        {
            decimal value = ReadDecimal();
            if (value >= min && value <= max)
                return value;
            Console.Write($"Ошибка: введите число от {min} до {max}: ");
        }
    }

    //  Чтение положительного дробного 
    public static decimal ReadPositiveDecimal()
    {
        while (true)
        {
            decimal value = ReadDecimal();
            if (value > 0)
                return value;
            Console.Write("Ошибка: число должно быть больше нуля. Повторите ввод: ");
        }
    }

    //  Чтение неотрицательного дробного 
    public static decimal ReadNonNegativeDecimal()
    {
        while (true)
        {
            decimal value = ReadDecimal();
            if (value >= 0)
                return value;
            Console.Write("Ошибка: число не может быть отрицательным. Повторите ввод: ");
        }
    }
}