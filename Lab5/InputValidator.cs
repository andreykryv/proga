using Spectre.Console;

/// <summary>
/// Класс для валидации пользовательского ввода
/// </summary>
public static class InputValidator
{
    /// <summary>
    /// Результат попытки ввода
    /// </summary>
    private class ValidationResult
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public int? IntValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public string? StringValue { get; set; }
    }

    /// <summary>
    /// Пытается получить целое число в заданном диапазоне
    /// Возвращает результат с информацией об успехе или ошибке
    /// </summary>
    private static ValidationResult TryGetIntInRange(string input, int min, int max)
    {
        var result = new ValidationResult();

        try
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Ввод не может быть пустым.");
            }

            if (!int.TryParse(input, out int parsedValue))
            {
                throw new FormatException("Введите корректное целое число.");
            }

            if (parsedValue < min || parsedValue > max)
            {
                throw new ArgumentOutOfRangeException($"Число должно быть в диапазоне от {min} до {max}.");
            }

            result.IsSuccess = true;
            result.IntValue = parsedValue;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            result.IsSuccess = false;
            result.ErrorMessage = ex.Message;
        }
        catch (FormatException ex)
        {
            result.IsSuccess = false;
            result.ErrorMessage = ex.Message;
        }
        catch (ArgumentException ex)
        {
            result.IsSuccess = false;
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

    /// <summary>
    /// Запрашивает у пользователя целое число в заданном диапазоне
    /// </summary>
    public static int GetIntInRange(string prompt, int min, int max)
    {
        while (true)
        {
            AnsiConsole.Write(new Markup($"[bold cyan]{prompt}[/] "));
            string? input = Console.ReadLine();

            var validationResult = TryGetIntInRange(input!, min, max);

            if (!validationResult.IsSuccess)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: {validationResult.ErrorMessage}[/]");
                continue;
            }

            return validationResult.IntValue!.Value;
        }
    }

    /// <summary>
    /// Пытается получить неотрицательное десятичное число
    /// Возвращает результат с информацией об успехе или ошибке
    /// </summary>
    private static ValidationResult TryGetNonNegativeDecimal(string input)
    {
        var result = new ValidationResult();

        try
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Ввод не может быть пустым.");
            }

            if (!decimal.TryParse(input, out decimal parsedValue))
            {
                throw new FormatException("Введите корректное десятичное число.");
            }

            if (parsedValue < 0)
            {
                throw new ArgumentOutOfRangeException("Значение не может быть отрицательным.");
            }

            result.IsSuccess = true;
            result.DecimalValue = parsedValue;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            result.IsSuccess = false;
            result.ErrorMessage = ex.Message;
        }
        catch (FormatException ex)
        {
            result.IsSuccess = false;
            result.ErrorMessage = ex.Message;
        }
        catch (ArgumentException ex)
        {
            result.IsSuccess = false;
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

    /// <summary>
    /// Запрашивает у пользователя десятичное число (не отрицательное)
    /// </summary>
    public static decimal GetNonNegativeDecimal(string prompt)
    {
        while (true)
        {
            AnsiConsole.Write(new Markup($"[bold cyan]{prompt}[/] "));
            string? input = Console.ReadLine();

            var validationResult = TryGetNonNegativeDecimal(input!);

            if (!validationResult.IsSuccess)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: {validationResult.ErrorMessage}[/]");
                continue;
            }

            return validationResult.DecimalValue!.Value;
        }
    }

    /// <summary>
    /// Пытается получить непустую строку
    /// Возвращает результат с информацией об успехе или ошибке
    /// </summary>
    private static ValidationResult TryGetNonEmptyString(string input)
    {
        var result = new ValidationResult();

        try
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Ввод не может быть пустым.");
            }

            result.IsSuccess = true;
            result.StringValue = input.Trim();
        }
        catch (ArgumentException ex)
        {
            result.IsSuccess = false;
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

    /// <summary>
    /// Запрашивает у пользователя непустую строку
    /// </summary>
    public static string GetNonEmptyString(string prompt)
    {
        while (true)
        {
            AnsiConsole.Write(new Markup($"[bold cyan]{prompt}[/] "));
            string? input = Console.ReadLine();

            var validationResult = TryGetNonEmptyString(input!);

            if (!validationResult.IsSuccess)
            {
                AnsiConsole.MarkupLine($"[red]Ошибка: {validationResult.ErrorMessage}[/]");
                continue;
            }

            return validationResult.StringValue!;
        }
    }

    /// <summary>
    /// Запрашивает выбор из списка опций
    /// </summary>
    public static int GetMenuSelection(string title, List<string> options)
    {
        var selectionPrompt = new SelectionPrompt<string>()
            .Title(title)
            .AddChoices(options);

        var selected = AnsiConsole.Prompt(selectionPrompt);
        return options.IndexOf(selected);
    }
}