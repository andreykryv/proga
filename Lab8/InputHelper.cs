using Spectre.Console;

/// <summary>
/// Вспомогательный класс для безопасного ввода данных с использованием Spectre.Console.
/// Все методы обрабатывают ошибки ввода и повторяют запрос до получения корректного значения.
/// </summary>
internal static class InputHelper   // изменили public на internal
{
    /// <summary>
    /// Ввод строки с необязательной валидацией.
    /// </summary>
    /// <param name="prompt">Сообщение для пользователя.</param>
    /// <param name="validator">Функция валидации (возвращает true, если значение корректно).</param>
    /// <param name="errorMessage">Сообщение об ошибке по умолчанию.</param>
    /// <returns>Введённая строка.</returns>
    public static string GetString(string prompt, Func<string, bool>? validator = null, string errorMessage = "Некорректный ввод.")
    {
        while (true)
        {
            var input = AnsiConsole.Ask<string>(prompt);
            if (validator == null || validator(input))
                return input;

            AnsiConsole.MarkupLine($"[red]{errorMessage}[/]");
        }
    }

    /// <summary>
    /// Ввод целого числа с ограничениями по диапазону.
    /// </summary>
    public static int GetInt(string prompt, int? min = null, int? max = null)
    {
        while (true)
        {
            try
            {
                var input = AnsiConsole.Ask<int>(prompt);
                if (min.HasValue && input < min.Value)
                    throw new ArgumentException($"Значение не может быть меньше {min.Value}.");
                if (max.HasValue && input > max.Value)
                    throw new ArgumentException($"Значение не может быть больше {max.Value}.");
                return input;
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            }
        }
    }

    /// <summary>
    /// Ввод вещественного числа с ограничениями по диапазону.
    /// </summary>
    public static decimal GetDecimal(string prompt, decimal? min = null, decimal? max = null)
    {
        while (true)
        {
            try
            {
                var input = AnsiConsole.Ask<decimal>(prompt);
                if (min.HasValue && input < min.Value)
                    throw new ArgumentException($"Значение не может быть меньше {min.Value}.");
                if (max.HasValue && input > max.Value)
                    throw new ArgumentException($"Значение не может быть больше {max.Value}.");
                return input;
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            }
        }
    }

    /// <summary>
    /// Выбор одного элемента из списка с помощью интерактивного меню.
    /// </summary>
    /// <typeparam name="T">Тип элементов.</typeparam>
    /// <param name="prompt">Заголовок меню.</param>
    /// <param name="items">Коллекция элементов для выбора.</param>
    /// <param name="converter">Функция преобразования элемента в строку (опционально).</param>
    /// <returns>Выбранный элемент.</returns>
    public static T GetChoice<T>(string prompt, IEnumerable<T> items, Func<T, string>? converter = null)
    {
        var list = items.ToList();
        if (!list.Any())
            throw new InvalidOperationException("Список выбора пуст.");

        converter ??= (x) => x?.ToString() ?? "<null>";
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<T>()
                .Title(prompt)
                .PageSize(10)
                .UseConverter(converter)
                .AddChoices(list));
        return choice;
    }

    /// <summary>
    /// Выбор существующего клиента по ID из списка.
    /// </summary>
    public static Client GetClientById(List<Client> clients, string prompt = "Выберите клиента:")
    {
        if (!clients.Any())
            throw new InvalidOperationException("Нет зарегистрированных клиентов.");

        return GetChoice(prompt, clients, c => $"{c.Id} – {c.Name} (трафик: {c.TrafficMb} МБ, тариф: {c.Tariff.Name})");
    }

    /// <summary>
    /// Ввод положительного количества трафика.
    /// </summary>
    public static decimal GetTraffic(string prompt = "Введите количество трафика (МБ):")
    {
        return GetDecimal(prompt, min: 0);
    }

    /// <summary>
    /// Ввод скидки в диапазоне [0, 1].
    /// </summary>
    public static decimal GetDiscount(string prompt = "Введите размер скидки (0..1, например 0.2 = 20%):")
    {
        return GetDecimal(prompt, min: 0, max: 1);
    }
}