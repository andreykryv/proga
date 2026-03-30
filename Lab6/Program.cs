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
        totalRanges[car] = car.availableRange;
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

    AnsiConsole.Write(new FigletText("Car Fleet Demo")
            .Centered()
            .Color(Color.Green));

    AnsiConsole.MarkupLine("[bold yellow]Welcome to the interactive car demonstration![/]\n");

    AnsiConsole.MarkupLine("[bold]Car Specifications:[/]");
    foreach (var car in cars)
        {
            string escapedHeader = Markup.Escape(GetModel(car));
            var panel = new Panel(new Text(car.PrintInfo())) 
                .Header(escapedHeader)
                .BorderColor(Color.Cyan1)
                .RoundedBorder();
                 AnsiConsole.Write(panel);
                 AnsiConsole.WriteLine();
        }

    AnsiConsole.MarkupLine("\n[bold yellow]--- Demonstration: Driving & Refueling ---[/]\n");

    void DriveWithProgress(Car car, int distance)
        {
            string model = Markup.Escape(GetModel(car)); 
            AnsiConsole.MarkupLine($"[bold]Driving {model} for {distance} km...[/]");
            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    var task = ctx.AddTask($"[green]Driving {model}[/]", new ProgressTaskSettings { MaxValue = distance });
                    while (!ctx.IsFinished)
                    {
                        if (task.Value + 10 >= distance)
                            task.Increment(distance - (int)task.Value);
                        else
                            task.Increment(10);
                        Thread.Sleep(100);
                    }
                });
            car.Drive(distance);
            AnsiConsole.MarkupLine($"  [blue]Remaining range: {car.availableRange} km[/]");
        }

        
        DriveWithProgress(bmw3, 5000);
        bmw3.Refuel();
        AnsiConsole.MarkupLine($"  [green]After refuel: {bmw3.availableRange} km[/]\n");
        DriveWithProgress(bmwM3, 5000);
        bmwM3.Refuel();
        AnsiConsole.MarkupLine($"  [green]After refuel: {bmwM3.availableRange} km[/]\n");    
        DriveWithProgress(bmwi3, 5000);
        bmwi3.Refuel();
        AnsiConsole.MarkupLine($"  [green]After charge: {bmwi3.availableRange} km[/]\n");

        AnsiConsole.MarkupLine("[bold yellow]--- All Cars Drive 100 km ---[/]\n");
        foreach (var car in cars)
        {
            DriveWithProgress(car, 100);
        }

    
    var table = new Table()
            .Border(TableBorder.Rounded)
            .Title("[bold green]Final Range Status[/]")
            .AddColumn("[yellow]Model[/]")
            .AddColumn("[yellow]Range Left (km)[/]")
            .AddColumn("[yellow]Max Range (km)[/]");

    foreach (var car in cars)
        {
            string model = Markup.Escape(GetModel(car));
            string color = car.availableRange <= 50 ? "red" : "green";
            table.AddRow(
                model,
                $"[{color}]{car.availableRange}[/]",
                $"{totalRanges[car]}");
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("\n[bold green]Demonstration completed! Press any key to exit...[/]");
        Console.ReadKey();
    }
}