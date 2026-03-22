class Task2
{
    public static void Run()
  {
     while (true)
     {
 double dotX;
 string? input1;
 double dotY;
 string? input2;
  while (true)
{
    Console.Write("Введите точку dotX: ");
    input1 = Console.ReadLine();

    if (double.TryParse(input1, out dotX))
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
    Console.Write("Введите делимое M: ");
    input2 = Console.ReadLine();

    if (double.TryParse(input2, out dotY))
    {
        break; 
    }
    else
    {
        Console.WriteLine("Ошибка: введите корректное число!\n");
    }
}
   double rFromZero = dotX * dotX + dotY * dotY; 
        double maxRadius = 9.0 * 9.0;   
        const double eps = 1e-9;   // погрешность для сравнения вещественных чисел 

        bool onArc      = Math.Abs(rFromZero - maxRadius) < eps && dotX >= -eps;
        bool onDiameter = Math.Abs(dotX) < eps && dotY >= -9 - eps && dotY <= 9 + eps;
        bool onBoundary = onArc || onDiameter;
        bool inside = dotX > eps && rFromZero < maxRadius - eps;

         if (onBoundary)
            Console.WriteLine("На границе");
        else if (inside)
            Console.WriteLine("Да,внутри");  
        else
            Console.WriteLine("Нет,снаружи"); 
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