using System;
using System.Globalization;

class DateService
{
   
    public string? ValidateDate(string date, bool detailed = false)
    {
    if (string.IsNullOrWhiteSpace(date))
    return "Ошибка: дата не может быть пустой.";

    if (!DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parsed))
        {
         
        if (detailed && date.Length == 10 && date[2] == '.' && date[5] == '.')
            {
                string[] parts = date.Split('.');
                if (parts.Length == 3 && parts[0] == "29" && parts[1] == "02")
                {
                if (int.TryParse(parts[2], out int year) && !IsLeapYear(year))
                return $"Ошибка: 29 февраля существует только в високосные годы. {year} год не является високосным.";
                }
            }
        return "Ошибка: неверный формат даты. Используйте дд.мм.гггг";
        }
        return null;
    }

    public string GetDay(string date)
    {
        string? validationError = ValidateDate(date, detailed: true);
        if (validationError != null)
        return validationError;

        DateTime parsedDate = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        return parsedDate.ToString("dddd", new CultureInfo("ru-RU"));
    }

    public int GetDaysSpan(int day, int month, int year)
    {
        DateTime targetDate = new DateTime(year, month, day);
        TimeSpan span = targetDate - DateTime.Today;
        return Math.Abs(span.Days);
    }

    public bool IsLeapYear(int year)
    {
        return DateTime.IsLeapYear(year);
    }
}