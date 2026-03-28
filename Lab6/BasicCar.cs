using System.Runtime.CompilerServices;

class BasicCar:Car
{
    
    private  int seats;
    private int? engineDisplacement;
    private BodyType body;
    private int availableRange;
    

    internal BasicCar(int seats, int? engineDisplacement,BodyType body,
    string model,int yearOfProduction, FuelType type, int horsePower, 
    int availableRange, int maxRange)
    :base(model,yearOfProduction, type,horsePower, maxRange)
    {   
        this.seats = seats;
        this.engineDisplacement = engineDisplacement;
        this.availableRange = availableRange;
       
        
        

        this.body = body;
    
    }
    
    internal int Seats => seats;
    internal int? EngineDisplacement => engineDisplacement;
    internal BodyType Body => body;




    internal override void Drive(int km)
    {
        Console.WriteLine($"Машина проехала {km} км");
        
        if (km <= availableRange)
        {
            availableRange -= km;
        }

        else
        {
           Console.WriteLine($"Машина проехала {availableRange} и {type} закончился");
           availableRange = 0;
        }
    }

    protected new void Rename(string model)
    {
        base.Rename(model);
    }
}