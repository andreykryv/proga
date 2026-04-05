using System.Runtime.CompilerServices;

class BasicCar:Car
{
    
    protected internal  int seats;
    protected internal float? engineDisplacement;
    protected internal BodyType body;
    
    

    internal BasicCar(int seats, float? engineDisplacement,BodyType body,
    string model,int yearOfProduction, FuelType type, int horsePower, 
    int availableRange, int maxRange)
    :base(model,yearOfProduction, type,horsePower, maxRange, availableRange)
    {   
        this.seats = seats;
        this.engineDisplacement = engineDisplacement;

       
        
        

        this.body = body;
    
    }
    
    protected internal int Seats => seats;
    protected internal float? EngineDisplacement => engineDisplacement;
    protected internal BodyType Body => body;




    protected internal override void Drive(int km)
    {
    if (km < 0)
        throw new ArgumentException("Расстояние не может быть отрицательным.");
    if (availableRange == 0)
        throw new InvalidOperationException($"Топливо закончилось, заправьте {model}.");
    
    if (km <= availableRange)
        availableRange -= km;
    else
    {
        int driven = availableRange;
        availableRange = 0;
        throw new InvalidOperationException(
            $"Топлива хватило только на {driven} км. {type} закончился.");
    }
}

    protected internal new void Rename(string model)
    {
        base.Rename(model);
    }
   
    protected internal override string PrintInfo()
    {
        return $@"        Автомобиль {model} {yearOfProduction} года выпуска.[BASIC] 
        {type} cиловая установка мощностью {horsePower} л.c объёмом {engineDisplacement}л.
        В кузове {body} и вместимостью {seats} мест
        Запас хода: {availableRange} км";}
    }