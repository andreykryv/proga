using Spectre.Console;





internal static class InputHelper   
{
    
    
    
    
    
    
    
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

    
    
    
    public static Client GetClientById(List<Client> clients, string prompt = "Выберите клиента:")
    {
        if (!clients.Any())
            throw new InvalidOperationException("Нет зарегистрированных клиентов.");

        return GetChoice(prompt, clients, c => $"{c.Id} – {c.Name} (трафик: {c.TrafficMb} МБ, тариф: {c.Tariff.Name})");
    }

    
    
    
    public static decimal GetTraffic(string prompt = "Введите количество трафика (МБ):")
    {
        return GetDecimal(prompt, min: 0);
    }

    
    
    
    public static decimal GetDiscount(string prompt = "Введите размер скидки (0..1, например 0.2 = 20%):")
    {
        return GetDecimal(prompt, min: 0, max: 1);
    }
}