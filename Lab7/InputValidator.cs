using System;
using Spectre.Console;

public class InputValidator
{
    /// <summary>
    /// Запрашивает у пользователя ввод числа типа double с проверкой корректности
    /// </summary>
    /// <param name="prompt">Текст приглашения к вводу</param>
    /// <param name="errorMessage">Сообщение об ошибке при некорректном вводе</param>
    /// <returns>Корректное значение типа double</returns>
    public static double ReadDouble(string prompt, string errorMessage = "Ошибка: введено некорректное число. Попробуйте снова.")
    {
        while (true)
        {
            try
            {
                AnsiConsole.MarkupLine($"[cyan]{prompt}[/]");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new FormatException("Ввод не может быть пустым.");
                }

                double result = double.Parse(input, System.Globalization.CultureInfo.InvariantCulture);
                return result;
            }
            catch (FormatException ex)
            {
                AnsiConsole.MarkupLine($"[red]{errorMessage} ({ex.Message})[/]");
            }
            catch (OverflowException ex)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: число слишком большое или слишком маленькое. ({ex.Message})[/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Неожиданная ошибка: {ex.Message}[/]");
            }
        }
    }

    /// <summary>
    /// Запрашивает у пользователя ввод положительного числа типа double
    /// </summary>
    /// <param name="prompt">Текст приглашения к вводу</param>
    /// <param name="errorMessage">Сообщение об ошибке при некорректном вводе</param>
    /// <param name="positiveErrorMessage">Сообщение об ошибке, если число не положительное</param>
    /// <returns>Корректное положительное значение типа double</returns>
    public static double ReadPositiveDouble(string prompt,
        string errorMessage = "Ошибка: введено некорректное число. Попробуйте снова.",
        string positiveErrorMessage = "Ошибка: число должно быть положительным.")
    {
        while (true)
        {
            double value = ReadDouble(prompt, errorMessage);

            if (value > 0)
            {
                return value;
            }

            AnsiConsole.MarkupLine($"[red]{positiveErrorMessage}[/]");
        }
    }

    /// <summary>
    /// Запрашивает у пользователя создание окружности через консоль
    /// </summary>
    /// <returns>Новый объект Circle с введенными параметрами</returns>
    public static Circle ReadCircleFromConsole()
    {
        AnsiConsole.Write(new Rule("[yellow]Ввод параметров окружности[/]"));

        double x = ReadDouble("Введите координату X центра окружности:");
        double y = ReadDouble("Введите координату Y центра окружности:");
        double radius = ReadPositiveDouble(
            "Введите радиус окружности:",
            "Ошибка: введено некорректное число.",
            "Ошибка: радиус должен быть положительным числом.");

        return new Circle(x, y, radius);
    }

    /// <summary>
    /// Запрашивает у пользователя выбор действия из меню
    /// </summary>
    /// <param name="options">Массив опций меню</param>
    /// <returns>Индекс выбранной опции</returns>
    public static int ReadMenuChoice(string[] options)
    {
        AnsiConsole.Write(new Rule("[yellow]Меню[/]"));

        for (int i = 0; i < options.Length; i++)
        {
            AnsiConsole.MarkupLine($"[green]{i + 1}.[/] {options[i]}");
        }

        while (true)
        {
            try
            {
                AnsiConsole.MarkupLine("[cyan]Выберите пункт меню (введите номер):[/]");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new FormatException("Ввод не может быть пустым.");
                }

                int choice = int.Parse(input);

                if (choice < 1 || choice > options.Length)
                {
                    throw new ArgumentOutOfRangeException($"Номер должен быть от 1 до {options.Length}");
                }

                return choice - 1;
            }
            catch (FormatException ex)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: введите корректный номер пункта меню. ({ex.Message})[/]");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: {ex.Message}[/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Неожиданная ошибка: {ex.Message}[/]");
            }
        }
    }
}