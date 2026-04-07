//вариант 9
using System;
using Spectre.Console;
class Program
{ static void Main()
    {
        try {Menu(); }
catch (Exception ex){   AnsiConsole.MarkupLine($"[red]Ошибка: {ex.Message}[/]");}
    }
    
       static void Menu(){
        Circle c1 = new Circle();                 
        Circle c2 = new Circle(3, 4, 2.5);      
        Circle c3 = new Circle(-1, 0, 5);         
        Circle c4 = 7.0;  //неявное преобразование



        AnsiConsole.Write(new Rule("[yellow]Созданные окружности[/]"));



        
        PrintCircleInfo(c1, "c1 (по умолчанию)");
        PrintCircleInfo(c2, "c2 (x=3, y=4, r=2.5)");
        PrintCircleInfo(c3, "c3 (x=-1, y=0, r=5)");
        PrintCircleInfo(c4, "c4 (неявное преобразование 7.0)");

        AnsiConsole.Write(new Rule("[yellow]Демонстрация операторов ++, --, *, /, унарный -[/]"));
        Circle temp = c2; 
        AnsiConsole.MarkupLine($"[cyan]Исходная окружность:[/]{temp}");
        temp++;
        AnsiConsole.MarkupLine($"[cyan]После ++ (радиус+1):[/]{temp}");
        temp--;
        AnsiConsole.MarkupLine($"[cyan]После -- (радиус-1):[/]{temp}");
        temp = -temp;
        AnsiConsole.MarkupLine($"[cyan]После унарного - (радиус-1):[/]{temp}");
        temp = temp * 2;
        AnsiConsole.MarkupLine($"[cyan]После *2:[/]{temp}");
        temp = temp / 2;
        AnsiConsole.MarkupLine($"[cyan]После /2:[/]{temp}");




        AnsiConsole.Write(new Rule("[yellow]Сравнение окружностей[/]"));
        CompareCircles(c1, c2);
        CompareCircles(c2, c3);
        CompareCircles(c1, c4);




        AnsiConsole.Write(new Rule("[yellow]Проверка операторов true/false (if(circle))[/]"));
        CheckCircleTruth(c1);
        CheckCircleTruth(c3);
        CheckCircleTruth(c4);



        AnsiConsole.Write(new Rule("[yellow]Явное преобразование в double[/]"));
        double radiusFromC4 = (double)c4;
        AnsiConsole.MarkupLine
        ($"Явное преобразование (double)c4 → [green]{radiusFromC4:F2}[/]");




        AnsiConsole.Write(new Rule("[blue]Демонстрация завершена[/]"));
    

       }

    static void PrintCircleInfo(Circle circle, string name){
        AnsiConsole.MarkupLine($"[bold]{name}:[/]");
        AnsiConsole.MarkupLine($"  ToString(): {circle}");
        AnsiConsole.MarkupLine
        ($"  Индексатор: x = {circle[0]:F2}, y = {circle[1]:F2}, r = {circle[2]:F2}");
        AnsiConsole.WriteLine();
    }



    static void CompareCircles(Circle a, Circle b) {
        AnsiConsole.MarkupLine($"[blue]Сравнение {a.Radius:F2} и {b.Radius:F2}:[/]");
        AnsiConsole.MarkupLine($"  a == b → {a == b}");
        AnsiConsole.MarkupLine($"  a != b → {a != b}");
        AnsiConsole.MarkupLine($"  a > b  → {a > b}");
        AnsiConsole.MarkupLine($"  a < b  → {a < b}");
        AnsiConsole.WriteLine();
    }



    static void CheckCircleTruth(Circle circle)
    {
        if (circle)
            AnsiConsole.MarkupLine
($"Окружность [green]{circle}[/] → [lime]true[/] (центр не в начале координат)");
        else
AnsiConsole.MarkupLine($"Окружность [red]{circle}[/] → [maroon]false[/] (центр в (0,0))");}


}