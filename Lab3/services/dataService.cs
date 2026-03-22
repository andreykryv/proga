using System.Globalization;

class DateService
{
    public string GetDay(string date)
    {
        if (string.IsNullOrWhiteSpace(date))
            return "Ошибка: дата не может быть пустой.";

        if (!DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parsedDate))
            return "Ошибка: неверный формат даты. Используйте дд.мм.гггг";

        return parsedDate.ToString("dddd", new CultureInfo("ru-RU"));
    }

    public int GetDaysSpan(int day, int month, int year)
    {
        DateTime targetDate = new DateTime(year, month, day);
        TimeSpan span = targetDate - DateTime.Today;
        return Math.Abs(span.Days);
    }
}