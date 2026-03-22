class Task1
{
    public static void Run()
    {
    while (true)
{int integerNumberM;
 string? input1;
 int integerNumberN;
 string? input2;
    while (true)
{
    Console.Write("Введите делимое M: ");
    input1 = Console.ReadLine();

    if (int.TryParse(input1, out integerNumberM))
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
    Console.Write("Введите делитель N: ");
    input2= Console.ReadLine();

    if (int.TryParse(input2, out integerNumberN) && integerNumberN != 0)
    {
        break; 
    }
    else
    {
        Console.WriteLine("Ошибка: введите корректное число!\n");
    }
}
     if (integerNumberM == 0)
    {
        Console.WriteLine($"Частное от деления равно: 0");
    }
    else if (integerNumberM % integerNumberN == 0)
    {
        int result = integerNumberM / integerNumberN;
        Console.WriteLine($"Частное от деления равно: {result}");
    }
    else
    {
        Console.WriteLine("M на N нацело не делится");
    }
    Console.WriteLine("Выбирете,что делать дальше: ");
    Console.WriteLine("1)Продолжить вычисления в заднии 1");
    Console.WriteLine("2)Завершить вычисления в задании 1");
    string? input;
   int continueOrNot;
   
    while (true)
    {
        
    input = Console.ReadLine();
  if (int.TryParse(input, out continueOrNot))
{ 
    if (continueOrNot == 2) { break; }
    else if (continueOrNot == 1) { break; }
    else { Console.WriteLine("Выберите корректный номер действия!"); }
}
else
{
    Console.WriteLine("Выберите корректный номер действия!");
}
  
    }
    if (continueOrNot == 2)
    {
        break;
    }
}
    }
}