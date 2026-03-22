//вариант 9 
class Task1
{
    public static void Run()
    {
         while (true)
{int integerNumber;
 string? input1;
 
    while (true)
{
    Console.Write("Введите число: ");
    input1 = Console.ReadLine();
     
    if (int.TryParse(input1, out integerNumber))
    {
     
       break; 
    }
    else
    {
        Console.WriteLine("Ошибка: введите корректное число!\n");
    }
}
    if (integerNumber >= 10 && integerNumber<= 99)
    {
        integerNumber = (integerNumber % 10) * 10 + (integerNumber / 10);
        Console.WriteLine(integerNumber);
    }
     else if (integerNumber <= -10 && integerNumber >= -99)
    {
        integerNumber = (integerNumber % 10) * 10 + (integerNumber / 10);
        Console.WriteLine(integerNumber);
    }
    else
    {   Console.WriteLine(integerNumber);
      
    
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