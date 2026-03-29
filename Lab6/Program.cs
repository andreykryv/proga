BasicCar bmw3 = new BasicCar(5,3.0f,BodyType.Sedan,"BMW 3 Series",2015,FuelType.Gas,300,
1000,1000);

SportsCar bmwM3 = new SportsCar(3.5f,2000,GearboxType.Manual,"bmw M3", 2017,
FuelType.Gas,510,1000,5,2.9f,BodyType.Wagon,1000);
ElectricCar bmwi3 = new ElectricCar(70,10,"bmw i3",2018,FuelType.Electricity,400,
5,null,BodyType.Sedan, 700);


Car carVariable = new BasicCar(5, 3.0f, BodyType.Sedan, "BMW 3 Series", 2015, FuelType.Gas, 300, 1000, 1000);
BasicCar basicCarVariable = new BasicCar(5, 3.0f, BodyType.Sedan, "BMW 3 Series", 2015, FuelType.Gas, 300, 1000, 1000);

carVariable.Rename("BMW 5 Series");      // вызовет Car.Rename()
basicCarVariable.Rename("BMW 5 Series"); // вызовет BasicCar.Rename()

Console.WriteLine(bmw3.PrintInfo());
Console.WriteLine();
Console.WriteLine(bmwM3.PrintInfo());
Console.WriteLine();
Console.WriteLine(bmwi3.PrintInfo());
bmw3.Drive(5000);
bmw3.Refuel();
Console.WriteLine(bmw3.availableRange);
bmwM3.Drive(5000);
bmwM3.Refuel();
Console.WriteLine(bmwM3.availableRange);
bmwi3.Drive(5000);
bmwi3.Refuel();
Console.WriteLine(bmwi3.availableRange);



  
     


       
  

    