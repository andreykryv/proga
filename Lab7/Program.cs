//вариант 9
using System;
using Spectre.Console;

class Program
{
    static void Main()
    {
        try
        {
            RunInteractiveMenu();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Ошибка: {ex.Message}[/]");
        }
    }

    static void RunInteractiveMenu()
    {
        AnsiConsole.Write(new Rule("[yellow]Лабораторная работа 7: Перегрузка операторов (Вариант 9 - Окружность)[/]"));

        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Выберите действие:[/]")
                    .AddChoices(new[]
                    {
                        "Создать окружность (конструктор)",
                        "Демонстрация ToString()",
                        "Демонстрация индексатора",
                        "Вычислить площадь и периметр",
                        "Операторы ++, --, -, *, /",
                        "Операторы сравнения ==, !=, <, >",
                        "Операторы true/false",
                        "Преобразования типа (double <-> Circle)",
                        "Выйти"
                    }));

            switch (choice)
            {
                case "Создать окружность (конструктор)":
                    DemonstrateConstructorsAndProperties();
                    break;
                case "Демонстрация ToString()":
                    DemonstrateToString();
                    break;
                case "Демонстрация индексатора":
                    DemonstrateIndexer();
                    break;
                case "Вычислить площадь и периметр":
                    DemonstrateMethods();
                    break;
                case "Операторы ++, --, -, *, /":
                    DemonstrateMathOperators();
                    break;
                case "Операторы сравнения ==, !=, <, >":
                    DemonstrateComparisonOperators();
                    break;
                case "Операторы true/false":
                    DemonstrateTrueFalseOperators();
                    break;
                case "Преобразования типа (double <-> Circle)":
                    DemonstrateConversions();
                    break;
                case "Выйти":
                    AnsiConsole.MarkupLine("[blue]Программа завершена.[/]");
                    return;
            }

            AnsiConsole.WriteLine();
            if (AnsiConsole.Confirm("[green]Продолжить?[/]"))
            {
                continue;
            }
            else
            {
                AnsiConsole.MarkupLine("[blue]Программа завершена.[/]");
                return;
            }
        }
    }

    static void DemonstrateConstructorsAndProperties()
    {
        AnsiConsole.Write(new Rule("[cyan]1. Конструкторы и свойства[/]"));

        // Запрос параметров у пользователя
        double x = InputValidator.ReadDouble("Введите координату X центра:");
        double y = InputValidator.ReadDouble("Введите координату Y центра:");
        double radius = InputValidator.ReadPositiveDouble("Введите радиус (положительное число):");

        Circle c2 = new Circle(x, y, radius);
        Circle c1 = new Circle(); // конструктор по умолчанию

        AnsiConsole.MarkupLine($"[green]c1 (по умолчанию):[/] X={c1.X}, Y={c1.Y}, Radius={c1.Radius}");
        AnsiConsole.MarkupLine($"[green]c2 (с вашими параметрами):[/] X={c2.X}, Y={c2.Y}, Radius={c2.Radius}");
        AnsiConsole.WriteLine();
    }

    static void DemonstrateToString()
    {
        AnsiConsole.Write(new Rule("[cyan]2. Перегрузка ToString()[/]"));

        double x = InputValidator.ReadDouble("Введите координату X:");
        double y = InputValidator.ReadDouble("Введите координату Y:");
        double radius = InputValidator.ReadPositiveDouble("Введите радиус:");

        Circle c = new Circle(x, y, radius);
        AnsiConsole.MarkupLine($"[green]ToString():[/] {c}");
        AnsiConsole.WriteLine();
    }

    static void DemonstrateIndexer()
    {
        AnsiConsole.Write(new Rule("[cyan]3. Индексатор[/]"));

        double x = InputValidator.ReadDouble("Введите координату X:");
        double y = InputValidator.ReadDouble("Введите координату Y:");
        double radius = InputValidator.ReadPositiveDouble("Введите радиус:");

        Circle c = new Circle(x, y, radius);
        AnsiConsole.MarkupLine($"[green]c[0] (X):[/] {c[0]}");
        AnsiConsole.MarkupLine($"[green]c[1] (Y):[/] {c[1]}");
        AnsiConsole.MarkupLine($"[green]c[2] (Radius):[/] {c[2]}");

        // Изменение через индексатор
        AnsiConsole.MarkupLine("[yellow]Изменим X через индексатор[/]");
        double newX = InputValidator.ReadDouble("Введите новое значение X:");
        c[0] = newX;
        AnsiConsole.MarkupLine($"[green]После c[0] = {newX}:[/] X={c.X}");
        AnsiConsole.WriteLine();
    }

    static void DemonstrateMethods()
    {
        AnsiConsole.Write(new Rule("[cyan]4. Методы вычисления площади и периметра[/]"));

        double x = InputValidator.ReadDouble("Введите координату X:");
        double y = InputValidator.ReadDouble("Введите координату Y:");
        double radius = InputValidator.ReadPositiveDouble("Введите радиус:");

        Circle c = new Circle(x, y, radius);
        AnsiConsole.MarkupLine($"[green]Окружность:[/] {c}");
        AnsiConsole.MarkupLine($"[green]Area (S = πr²):[/] {c.Area:F2}");
        AnsiConsole.MarkupLine($"[green]Perimeter (P = 2πr):[/] {c.Perimeter:F2}");
        AnsiConsole.WriteLine();
    }

    static void DemonstrateMathOperators()
    {
        AnsiConsole.Write(new Rule("[cyan]5. Математические операторы: ++, --, -, *, /[/]"));

        double x = InputValidator.ReadDouble("Введите координату X:");
        double y = InputValidator.ReadDouble("Введите координату Y:");
        double radius = InputValidator.ReadPositiveDouble("Введите радиус:");

        Circle c = new Circle(x, y, radius);
        AnsiConsole.MarkupLine($"[green]Исходная:[/] Radius={c.Radius}");

        AnsiConsole.MarkupLine("[yellow]Применяем ++[/]");
        c++;
        AnsiConsole.MarkupLine($"[green]После ++:[/] Radius={c.Radius}");

        AnsiConsole.MarkupLine("[yellow]Применяем --[/]");
        c--;
        AnsiConsole.MarkupLine($"[green]После --:[/] Radius={c.Radius}");

        AnsiConsole.MarkupLine("[yellow]Применяем унарный -[/]");
        c = -c;
        AnsiConsole.MarkupLine($"[green]После унарного -:[/] Radius={c.Radius}");

        double mult = InputValidator.ReadDouble("Введите множитель для *:");
        c = c * mult;
        AnsiConsole.MarkupLine($"[green]После *{mult}:[/] Radius={c.Radius}");

        double div = InputValidator.ReadDouble("Введите делитель для /:");
        if (div != 0)
        {
            c = c / div;
            AnsiConsole.MarkupLine($"[green]После /{div}:[/] Radius={c.Radius}");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Деление на 0 невозможно[/]");
        }
        AnsiConsole.WriteLine();
    }

    static void DemonstrateComparisonOperators()
    {
        AnsiConsole.Write(new Rule("[cyan]6. Операторы сравнения: ==, !=, <, >[/]"));

        AnsiConsole.MarkupLine("[yellow]Введите параметры первой окружности:[/]");
        double x1 = InputValidator.ReadDouble("Введите координату X1:");
        double y1 = InputValidator.ReadDouble("Введите координату Y1:");
        double r1 = InputValidator.ReadPositiveDouble("Введите радиус R1:");
        Circle c1 = new Circle(x1, y1, r1);

        AnsiConsole.MarkupLine("[yellow]Введите параметры второй окружности:[/]");
        double x2 = InputValidator.ReadDouble("Введите координату X2:");
        double y2 = InputValidator.ReadDouble("Введите координату Y2:");
        double r2 = InputValidator.ReadPositiveDouble("Введите радиус R2:");
        Circle c2 = new Circle(x2, y2, r2);

        AnsiConsole.MarkupLine($"[green]c1 (r={r1}) == c2 (r={r2}):[/] {c1 == c2}");
        AnsiConsole.MarkupLine($"[green]c1 (r={r1}) != c2 (r={r2}):[/] {c1 != c2}");
        AnsiConsole.MarkupLine($"[green]c1 (r={r1}) < c2 (r={r2}):[/] {c1 < c2} (сравнение по площади)");
        AnsiConsole.MarkupLine($"[green]c1 (r={r1}) > c2 (r={r2}):[/] {c1 > c2} (сравнение по площади)");
        AnsiConsole.WriteLine();
    }

    static void DemonstrateTrueFalseOperators()
    {
        AnsiConsole.Write(new Rule("[cyan]7. Операторы true/false[/]"));

        double x = InputValidator.ReadDouble("Введите координату X:");
        double y = InputValidator.ReadDouble("Введите координату Y:");
        double radius = InputValidator.ReadPositiveDouble("Введите радиус:");

        Circle c = new Circle(x, y, radius);

        AnsiConsole.MarkupLine($"[green]Окружность:[/] {c}");
        AnsiConsole.MarkupLine($"[green]Результат проверки (центр в начале координат = false):[/] {(c ? "true" : "false")}");

        if (c)
            AnsiConsole.MarkupLine("[green]Центр НЕ в начале координат[/]");
        else
            AnsiConsole.MarkupLine("[green]Центр в начале координат (0,0)[/]");
        AnsiConsole.WriteLine();
    }

    static void DemonstrateConversions()
    {
        AnsiConsole.Write(new Rule("[cyan]8. Преобразования типа[/]"));

        // Неявное преобразование double → Circle
        double radius = InputValidator.ReadDouble("Введите значение double для неявного преобразования в Circle:");
        Circle c = radius; // неявно вызывается implicit operator Circle(double d)
        AnsiConsole.MarkupLine($"[green]Неявное: Circle c = {radius} →[/] Radius={c.Radius}, X={c.X}, Y={c.Y}");

        // Явное преобразование Circle → double
        double result = (double)c; // явно вызывается explicit operator double(Circle)
        AnsiConsole.MarkupLine($"[green]Явное: (double)c →[/] {result}");
        AnsiConsole.WriteLine();
    }

    static void DemonstrateConsoleInput()
    {
        AnsiConsole.Write(new Rule("[cyan]9. Ввод через консоль с валидацией[/]"));

        AnsiConsole.MarkupLine("[yellow]Введите параметры окружности:[/]");

        double x = InputValidator.ReadDouble("Введите координату X:");
        double y = InputValidator.ReadDouble("Введите координату Y:");
        double radius = InputValidator.ReadPositiveDouble("Введите радиус (положительное число):");

        Circle userCircle = new Circle(x, y, radius);
        AnsiConsole.MarkupLine($"[green]Создана окружность:[/] {userCircle}");
        AnsiConsole.WriteLine();
    }
}