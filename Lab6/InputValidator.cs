using Spectre.Console;

/// <summary>
/// Класс для валидации пользовательского ввода с использованием Spectre.Console
/// </summary>
static class InputValidator
{
    /// <summary>
    /// Запрашивает целое число у пользователя с валидацией
    /// </summary>
    /// <param name="prompt">Текст запроса</param>
    /// <param name="minValue">Минимальное допустимое значение</param>
    /// <param name="maxValue">Максимальное допустимое значение (nullable)</param>
    /// <param name="minErrorMessage">Сообщение об ошибке при значении меньше минимума</param>
    /// <param name="maxErrorMessage">Сообщение об ошибке при значении больше максимума</param>
    /// <returns>Валидное целое число</returns>
    public static int GetInt(
        string prompt,
        int minValue = int.MinValue,
        int? maxValue = null,
        string? minErrorMessage = null,
        string? maxErrorMessage = null)
    {
        minErrorMessage ??= $"[red]Значение должно быть не меньше {minValue}[/]";
        maxErrorMessage ??= $"[red]Значение должно быть не больше {maxValue}[/]";

        var textPrompt = new TextPrompt<int>(prompt)
            .Validate(x => x >= minValue, minErrorMessage);

        if (maxValue.HasValue)
        {
            textPrompt.Validate(x => x <= maxValue.Value, maxErrorMessage);
        }

        return AnsiConsole.Prompt(textPrompt);
    }

    /// <summary>
    /// Запрашивает положительное целое число (больше 0)
    /// </summary>
    /// <param name="prompt">Текст запроса</param>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    /// <returns>Положительное целое число</returns>
    public static int GetPositiveInt(string prompt, string? errorMessage = null)
    {
        errorMessage ??= "[red]Значение должно быть положительным (больше 0)[/]";

        return AnsiConsole.Prompt(
            new TextPrompt<int>(prompt)
                .Validate(x => x > 0, errorMessage));
    }

    /// <summary>
    /// Запрашивает неотрицательное целое число (>= 0)
    /// </summary>
    /// <param name="prompt">Текст запроса</param>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    /// <returns>Неотрицательное целое число</returns>
    public static int GetNonNegativeInt(string prompt, string? errorMessage = null)
    {
        errorMessage ??= "[red]Значение не может быть отрицательным[/]";

        return AnsiConsole.Prompt(
            new TextPrompt<int>(prompt)
                .Validate(x => x >= 0, errorMessage));
    }

    /// <summary>
    /// Запрашивает строку у пользователя с проверкой на пустоту
    /// </summary>
    /// <param name="prompt">Текст запроса</param>
    /// <param name="allowEmpty">Разрешить ли пустую строку</param>
    /// <param name="errorMessage">Сообщение об ошибке при пустой строке</param>
    /// <returns>Введенная строка</returns>
    public static string GetString(
        string prompt,
        bool allowEmpty = false,
        string? errorMessage = null)
    {
        errorMessage ??= "[red]Строка не может быть пустой[/]";

        if (allowEmpty)
        {
            return AnsiConsole.Ask<string>(prompt);
        }

        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
                .Validate(s => !string.IsNullOrWhiteSpace(s), errorMessage));
    }

    /// <summary>
    /// Запрашивает выбор Yes/No у пользователя
    /// </summary>
    /// <param name="question">Вопрос пользователю</param>
    /// <param name="defaultValue">Значение по умолчанию</param>
    /// <returns>true если выбрано Yes, иначе false</returns>
    public static bool Confirm(string question, bool defaultValue = false)
    {
        return AnsiConsole.Confirm(question, defaultValue);
    }

    /// <summary>
    /// Запрашивает выбор из списка с помощью SelectionPrompt
    /// </summary>
    /// <typeparam name="T">Тип элементов выбора (не может быть null)</typeparam>
    /// <param name="title">Заголовок меню</param>
    /// <param name="choices">Список вариантов выбора</param>
    /// <param name="pageSize">Количество отображаемых элементов</param>
    /// <returns>Выбранный элемент</returns>
    public static T SelectFromList<T>(
        string title,
        IList<T> choices,
        int pageSize = 10) where T : notnull
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<T>()
                .Title(title)
                .PageSize(pageSize)
                .AddChoices(choices));
    }

    /// <summary>
    /// Запрашивает выбор индекса из диапазона
    /// </summary>
    /// <param name="prompt">Текст запроса</param>
    /// <param name="minIndex">Минимальный индекс (обычно 0 или 1)</param>
    /// <param name="maxIndex">Максимальный индекс</param>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    /// <returns>Валидный индекс</returns>
    public static int GetIndex(
        string prompt,
        int minIndex,
        int maxIndex,
        string? errorMessage = null)
    {
        errorMessage ??= $"[red]Введите индекс от {minIndex} до {maxIndex}[/]";

        return AnsiConsole.Prompt(
            new TextPrompt<int>(prompt)
                .Validate(x => x >= minIndex && x <= maxIndex, errorMessage));
    }
}