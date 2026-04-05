using Spectre.Console;
using YourNamespace;

namespace YourNamespace
{
    internal static class Validation
    {
        public static bool CheckOperator(Operator? op)
        {
            if (op == null)
            {
                AnsiConsole.MarkupLine("[red]Ошибка: оператор ещё не создан.[/]");
                Pause();
                return false;
            }
            return true;
        }
        public static int ReadNonNegativeInteger()
        {
            int value;
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out value) && value >= 0)
                    return value;
                AnsiConsole.MarkupLine("[red]Некорректный ввод. Введите неотрицательное целое число.[/]");
            }
        }
        public static decimal ReadPositiveDecimal()
        {
            decimal value;
            while (true)
            {
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out value) && value > 0)
                    return value;
                AnsiConsole.MarkupLine("[red]Некорректный ввод. Введите положительное число.[/]");
            }
        }
        public static decimal ReadDecimal()
        {
            decimal value;
            while (true)
            {
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out value))
                    return value;
                AnsiConsole.MarkupLine("[red]Некорректный ввод. Введите число.[/]");
            }
        }
        public static int ReadInteger()
        {
            int value;
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out value))
                    return value;
                AnsiConsole.MarkupLine("[red]Некорректный ввод. Введите целое число.[/]");
            }
        }
        public static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
        }
    }
}