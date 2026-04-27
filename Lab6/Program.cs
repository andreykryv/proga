// Add these using directives at the top if not already present
using System;
using System.Collections.Generic;
using System.Threading;
using Spectre.Console;


class Program
{
    static void Main()
    {
        BasicCar bmw3 = new BasicCar(5, 2.0f, BodyType.Sedan, "BMW 320i", 2021,
        FuelType.Gas, 184, 600, 600);
        SportsCar bmwM3 = new SportsCar(3.6f, 1830, GearboxType.Manual, "BMW M3 Touring",
        2022, FuelType.Gas, 510, 450, 5, 3.0f, BodyType.Wagon, 450);
        ElectricCar bmwi3 = new ElectricCar(42, 6, "BMW i3", 2018, FuelType.Electricity,
        170, 4, null, BodyType.Hatchback, 252);

        BasicCar PorscheMacan = new BasicCar(5, 2.0f, BodyType.Suv, "Porsche Macan", 2022,
        FuelType.Gas, 265, 550, 550);
        SportsCar PorscheMacanGTS = new SportsCar(4.1f, 1985, GearboxType.Automatic,
        "Porsche Macan GTS", 2022, FuelType.Gas, 380, 500, 5, 2.9f, BodyType.Suv, 500);
        ElectricCar PorscheMacanEV = new ElectricCar(100, 6, "Porsche Macan Electric", 2024,
        FuelType.Electricity, 408, 5, null, BodyType.Suv, 600);

        BasicCar VWgolf = new BasicCar(5, 1.5f, BodyType.Hatchback, "VW Golf", 2021,
        FuelType.Gas, 130, 650, 650);
        SportsCar VWgolfGTI = new SportsCar(6.3f, 1500, GearboxType.Automatic, "VW Golf GTI",
        2021, FuelType.Gas, 245, 600, 5, 2.0f, BodyType.Hatchback, 600);
        ElectricCar VWgolfID3 = new ElectricCar(77, 6, "VW ID.3", 2022, FuelType.Electricity,
        204, 5, null, BodyType.Hatchback, 550);


        Car[] cars = { bmw3, bmwM3, bmwi3, PorscheMacan, PorscheMacanGTS, PorscheMacanEV,
                           VWgolf, VWgolfGTI, VWgolfID3 };


        var totalRanges = new Dictionary<Car,int>();
        foreach (var car in cars)
            {
            totalRanges[car] = car.MaxRange;
            }
         string GetModel(Car car)
            {
                string info = car.PrintInfo();
                // Find the first line break
                int newline = info.IndexOf('\n');
                if (newline > 0) info = info.Substring(0, newline);
                // Now extract before dash or parenthesis
                int dash = info.IndexOf('-');
                if (dash > 0) return info.Substring(0, dash).Trim();
                int paren = info.IndexOf('(');
                if (paren > 0) return info.Substring(0, paren).Trim();
                return info.Trim();
            }

        AnsiConsole.Write(new FigletText("Car Fleet Menu")
                .Centered()
                .Color(Color.Green));

        AnsiConsole.MarkupLine("[bold yellow]Welcome to the interactive car fleet management system![/]\n");

        bool exit = false;
        int lastDriveDistance = 100; // Значение по умолчанию

        while (!exit)
        {
            var mainMenu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold cyan]Main Menu[/]")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "[green]View All Cars[/]",
                        "[blue]Select Car for Actions[/]",
                        $"[yellow]Drive All Cars {lastDriveDistance} km[/]",
                        "[magenta]Set Distance & Drive All Cars[/]",
                        "[cyan]Show Range Statistics[/]",
                        "[red]Exit[/]"
                    }));

            if (mainMenu == "[green]View All Cars[/]")
            {
                ViewAllCars(cars, GetModel);
            }
            else if (mainMenu == "[blue]Select Car for Actions[/]")
            {
                CarActionsMenu(cars, GetModel);
            }
            else if (mainMenu.StartsWith("[yellow]Drive All Cars"))
            {
                DriveAllCars(cars, GetModel, lastDriveDistance);
            }
            else if (mainMenu == "[magenta]Set Distance & Drive All Cars[/]")
            {
                lastDriveDistance = InputValidator.GetPositiveInt(
                    "[bold]Enter distance to drive for all cars (km):[/]");

                // Дополнительная проверка на разумное расстояние
                int maxReasonableDistance = 1000;
                if (lastDriveDistance > maxReasonableDistance)
                {
                    AnsiConsole.MarkupLine($"[yellow]Расстояние {lastDriveDistance} км очень большое. Возможно, стоит выбрать меньшее значение.[/]");
                    if (!InputValidator.Confirm("Продолжить с этим расстоянием?"))
                    {
                        lastDriveDistance = maxReasonableDistance;
                        AnsiConsole.MarkupLine($"[green]Расстояние изменено на {maxReasonableDistance} км[/]");
                    }
                }

                DriveAllCars(cars, GetModel, lastDriveDistance);
            }
            else if (mainMenu == "[cyan]Show Range Statistics[/]")
            {
                ShowRangeStatistics(cars, totalRanges, GetModel);
            }
            else if (mainMenu == "[red]Exit[/]")
            {
                exit = true;
                AnsiConsole.MarkupLine("\n[bold green]Thank you for using Car Fleet Menu! Goodbye![/]\n");
            }
        }
    }

    static void ViewAllCars(Car[] cars, Func<Car, string> getModel)
    {
        AnsiConsole.MarkupLine("\n[bold cyan]--- All Cars in Fleet ---[/]\n");

        foreach (var car in cars)
        {
            string escapedHeader = Markup.Escape(getModel(car));
            var panel = new Panel(new Text(car.PrintInfo()))
                .Header(escapedHeader)
                .BorderColor(Color.Cyan1)
                .RoundedBorder();
            AnsiConsole.Write(panel);
            AnsiConsole.WriteLine();
        }

        AnsiConsole.MarkupLine("[dim]Press any key to continue...[/]");
        Console.ReadKey();
    }

    static void CarActionsMenu(Car[] cars, Func<Car, string> getModel)
    {
        var carChoices = new List<(string display, Car? car)>();
        for (int i = 0; i < cars.Length; i++)
        {
            string modelName = getModel(cars[i]);
            string rangeInfo = $"[{(cars[i].AvailableRange <= 50 ? "red" : "green")}]{cars[i].AvailableRange} km[/]";
            carChoices.Add((($"[cyan]{i + 1}. {Markup.Escape(modelName)} - Range: {rangeInfo}[/]"), cars[i]));
        }
        carChoices.Add((($"[yellow]{carChoices.Count + 1}. Back to Main Menu[/]"), null));

        while (true)
        {
            var selected = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold blue]Select a Car[/]")
                    .PageSize(12)
                    .AddChoices(carChoices.Select(c => c.display)));

            int selectedIndex = carChoices.FindIndex(c => c.display == selected);
            if (selectedIndex == carChoices.Count - 1)
                break;

            Car? selectedCar = carChoices[selectedIndex].car;
            if (selectedCar == null)
                break;

            string modelName = getModel(selectedCar);

            var actionMenu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[bold magenta]Actions for {Markup.Escape(modelName)}[/]")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "[green]View Details[/]",
                        "[blue]Drive[/]",
                        "[yellow]Refuel/Charge[/]",
                        "[cyan]Back to Car Selection[/]"
                    }));

            switch (actionMenu)
            {
                case "[green]View Details[/]":
                    ViewCarDetails(selectedCar, getModel);
                    break;

                case "[blue]Drive[/]":
                    DriveCar(selectedCar, getModel);
                    break;

                case "[yellow]Refuel/Charge[/]":
                    RefuelCar(selectedCar, getModel);
                    break;

                case "[cyan]Back to Car Selection[/]":
                    break;
            }
        }
    }

    static void ViewCarDetails(Car car, Func<Car, string> getModel)
    {
        string modelName = Markup.Escape(getModel(car));
        var panel = new Panel(new Text(car.PrintInfo()))
            .Header(modelName)
            .BorderColor(Color.Green)
            .RoundedBorder();
        AnsiConsole.Write(panel);
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine("[dim]Press any key to continue...[/]");
        Console.ReadKey();
    }

    static void DriveCar(Car car, Func<Car, string> getModel)
    {
        string modelName = Markup.Escape(getModel(car));

        // Используем GetPositiveInt для расстояния (должно быть > 0)
        int distance = InputValidator.GetPositiveInt(
            $"[bold]Enter distance to drive (km) for {modelName}:[/]");

        // Проверка на превышение доступного запаса хода
        if (distance > car.AvailableRange)
        {
            AnsiConsole.MarkupLine($"[yellow]Расстояние {distance} км превышает доступный запас хода ({car.AvailableRange} км).[/]");
            bool continueAnyway = InputValidator.Confirm("Продолжить с этим расстоянием (машина проедет только доступное расстояние)?");

            if (!continueAnyway)
            {
                AnsiConsole.MarkupLine("[green]Поездка отменена.[/]");
                return; // Выход из метода, машина не едет
            }

            // Если пользователь согласился, машина проедет максимально возможное расстояние
            distance = (int)car.AvailableRange;
            AnsiConsole.MarkupLine($"[yellow]Расстояние изменено на максимальное доступное: {distance} км[/]");
        }
        // Дополнительная проверка на очень большое расстояние относительно максимального запаса хода
        else if (distance > car.MaxRange)
        {
            AnsiConsole.MarkupLine($"[yellow]Расстояние {distance} км превышает максимальный запас хода ({car.MaxRange} км). Это может быть опасно для батареи/двигателя.[/]");
            if (!InputValidator.Confirm("Продолжить с этим расстоянием?"))
            {
                distance = car.MaxRange;
                AnsiConsole.MarkupLine($"[green]Расстояние изменено на {distance} км[/]");
            }
        }

        AnsiConsole.MarkupLine($"\n[bold]Driving {modelName} for {distance} km...[/]");

        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var task = ctx.AddTask($"[green]Driving {modelName}[/]",
                    new ProgressTaskSettings { MaxValue = distance });
                while (!ctx.IsFinished)
                {
                    if (task.Value + 10 >= distance)
                        task.Increment(distance - (int)task.Value);
                    else
                        task.Increment(10);
                    Thread.Sleep(100);
                }
            });

        try
        {
            car.Drive(distance);
            AnsiConsole.MarkupLine($"  [blue]Remaining range: {car.AvailableRange} km[/]");
        }
        catch (InvalidOperationException ex)
        {
            AnsiConsole.MarkupLine($"  [red]Ошибка: {Markup.Escape(ex.Message)}[/]");
            AnsiConsole.MarkupLine($"  [blue]Remaining range: {car.AvailableRange} km[/]");
        }
        catch (ArgumentException ex)
        {
            AnsiConsole.MarkupLine($"  [red]Ошибка: {Markup.Escape(ex.Message)}[/]");
        }

        AnsiConsole.MarkupLine("\n[dim]Press any key to continue...[/]");
        Console.ReadKey();
    }

    static void RefuelCar(Car car, Func<Car, string> getModel)
    {
        string modelName = Markup.Escape(getModel(car));
        AnsiConsole.MarkupLine($"\n[bold yellow]Refueling/Charging {modelName}...[/]");

        try
        {
            car.Refuel();
            AnsiConsole.MarkupLine($"  [green]After refuel/charge: {car.AvailableRange} km[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"  [red]Ошибка: {Markup.Escape(ex.Message)}[/]");
        }

        AnsiConsole.MarkupLine("\n[dim]Press any key to continue...[/]");
        Console.ReadKey();
    }

    static void DriveAllCars(Car[] cars, Func<Car, string> getModel, int distance)
    {
        AnsiConsole.MarkupLine($"\n[bold yellow]--- All Cars Drive {distance} km ---[/]\n");

        foreach (var car in cars)
        {
            string modelName = Markup.Escape(getModel(car));
            AnsiConsole.MarkupLine($"[bold]Driving {modelName}...[/]");

            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    var task = ctx.AddTask($"[green]Driving {modelName}[/]",
                        new ProgressTaskSettings { MaxValue = distance });
                    while (!ctx.IsFinished)
                    {
                        if (task.Value + 10 >= distance)
                            task.Increment(distance - (int)task.Value);
                        else
                            task.Increment(10);
                        Thread.Sleep(50);
                    }
                });

            try
            {
                car.Drive(distance);
                AnsiConsole.MarkupLine($"  [blue]Remaining range: {car.AvailableRange} km[/]");
            }
            catch (InvalidOperationException ex)
            {
                AnsiConsole.MarkupLine($"  [red]Ошибка: {Markup.Escape(ex.Message)}[/]");
                AnsiConsole.MarkupLine($"  [blue]Remaining range: {car.AvailableRange} km[/]");
            }
            catch (ArgumentException ex)
            {
                AnsiConsole.MarkupLine($"  [red]Ошибка: {Markup.Escape(ex.Message)}[/]");
            }
        }

        AnsiConsole.MarkupLine("\n[dim]Press any key to continue...[/]");
        Console.ReadKey();
    }

    static void ShowRangeStatistics(Car[] cars, Dictionary<Car, int> totalRanges, Func<Car, string> getModel)
    {
        AnsiConsole.MarkupLine("\n[bold cyan]--- Range Statistics ---[/]\n");

        var table = new Table()
                .Border(TableBorder.Rounded)
                .Title("[bold green]Current Range Status[/]")
                .AddColumn("[yellow]Model[/]")
                .AddColumn("[yellow]Type[/]")
                .AddColumn("[yellow]Range Left (km)[/]")
                .AddColumn("[yellow]Max Range (km)[/]")
                .AddColumn("[yellow]Usage %[/]");

        foreach (var car in cars)
        {
            string model = Markup.Escape(getModel(car));
            string typeStr = car.Type.ToString();
            int currentRange = car.AvailableRange;
            int maxRange = totalRanges[car];
            int usagePercent = (int)((maxRange - currentRange) * 100.0 / maxRange);

            string rangeColor = currentRange <= 50 ? "red" : (currentRange <= 150 ? "yellow" : "green");
            string usageColor = usagePercent >= 80 ? "red" : (usagePercent >= 50 ? "yellow" : "green");

            table.AddRow(
                model,
                typeStr,
                $"[{rangeColor}]{currentRange}[/]",
                $"{maxRange}",
                $"[{usageColor}]{usagePercent}%[/]");
        }

        AnsiConsole.Write(table);

        // Summary statistics
        int totalCurrent = 0;
        int totalMax = 0;
        foreach (var car in cars)
        {
            totalCurrent += car.AvailableRange;
            totalMax += totalRanges[car];
        }

        AnsiConsole.MarkupLine($"\n[bold]Fleet Summary:[/]");
        AnsiConsole.MarkupLine($"  Total Range Available: [green]{totalCurrent} km[/]");
        AnsiConsole.MarkupLine($"  Total Max Range: [cyan]{totalMax} km[/]");
        AnsiConsole.MarkupLine($"  Fleet Efficiency: [yellow]{(totalCurrent * 100 / totalMax)}%[/]");

        AnsiConsole.MarkupLine("\n[dim]Press any key to continue...[/]");
        Console.ReadKey();
    }
}