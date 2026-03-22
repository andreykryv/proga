//вариант 7


class Task2
{
    public static void Run()
    {while (true)
{ double numberZ;
 string? inputZ;
 double numberC;
 string? inputC;
 double numberK;
 string? inputK;
 double numberD;
 string ? inputD;
double x = 0;
    while (true)
{
    Console.Write("Введите коэффициент z: ");
    inputZ = Console.ReadLine();
     
    if (double.TryParse(inputZ, out  numberZ))
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
    Console.Write("Введите коэффициент c: ");
    inputC = Console.ReadLine();
     
    if (double.TryParse(inputC, out  numberC))
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
    Console.Write("Введите коэффициент k: ");
    inputK = Console.ReadLine();
     
    if (double.TryParse(inputK, out  numberK))
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
    Console.Write("Введите коэффициент d: ");
    inputD = Console.ReadLine();
     
    if (double.TryParse(inputD, out  numberD))
    {
     
       break; 
    }
    else
    {
        Console.WriteLine("Ошибка: введите корректное число!\n");
    }
}
    if ( numberZ >= 0)
    {
        x = Math.Pow(numberZ,3);
    }
    else
    {
       x = numberZ * numberZ - numberZ;  
    }
    double sin = Math.Sin(numberC * x + numberD * numberD + numberK * x * x);
    double y = Math.Pow(sin,3);
    Console.WriteLine(y);
    
    Console.WriteLine("Выбирете,что делать дальше: ");
    Console.WriteLine("1)Продолжить вычисления в задании 2");
    Console.WriteLine("2)Завершить вычисления в задании 2");
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