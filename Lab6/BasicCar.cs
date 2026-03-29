using System.Runtime.CompilerServices;

class BasicCar:Car
{
    
    protected internal  int seats;
    protected internal float? engineDisplacement;
    protected internal BodyType body;
    protected internal int availableRange;
    

    internal BasicCar(int seats, float? engineDisplacement,BodyType body,
    string model,int yearOfProduction, FuelType type, int horsePower, 
    int availableRange, int maxRange)
    :base(model,yearOfProduction, type,horsePower, maxRange)
    {   
        this.seats = seats;
        this.engineDisplacement = engineDisplacement;
        this.availableRange = availableRange;
       
        
        

        this.body = body;
    
    }
    
    protected internal int Seats => seats;
    protected internal float? EngineDisplacement => engineDisplacement;
    protected internal BodyType Body => body;




    protected internal override void Drive(int km)
    {
        
        
        if (km <= availableRange)
        {   Console.WriteLine($"Машина проехала {km} км");
            availableRange -= km;
        }

        else
        {
           Console.WriteLine($"Машина проехала {availableRange} км и {type} закончился");
           availableRange = 0;
        }
    }

    protected internal new void Rename(string model)
    {
        base.Rename(model);
    }
    protected internal override void Refuel()
    {
        availableRange = maxRange;
        Console.WriteLine($"{model} был заправлен");
    }
    protected internal override string PrintInfo()
    {
        return $@"        Автомобиль {model} {yearOfProduction} года выпуска.[BASIC] 
        {type} cиловая установка мощностью {horsePower} л.c объёмом {engineDisplacement}л.
        В кузове {body} и вместимостью {seats} мест
        Запас хода: {availableRange} км";}
    }