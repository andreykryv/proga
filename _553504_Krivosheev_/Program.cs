// See https://aka.ms/new-console-template for more information
using System.IO.Pipelines;
string? input1;
string? input2;
double firstNumber;
double secondNumber;
double result;

while (true)
{
    Console.Write("Введите первое число: ");
    input1 = Console.ReadLine();

    if (double.TryParse(input1, out firstNumber))
    {
        break; 
    }
    else
    {
        Console.WriteLine("Ошибка: введите корректное число!\n");
    }
}

while (true)
{
    Console.Write("Введите второе число ");
    input2 = Console.ReadLine();

    if (double.TryParse(input2, out secondNumber) && secondNumber != 0)
    {
        break; 
    }
    else
    {
        Console.WriteLine("Ошибка: введите корректное число!\n");
    }
}

result = firstNumber / secondNumber;
Console.WriteLine($"Частное от деления: {result}");

