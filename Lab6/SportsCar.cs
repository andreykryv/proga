using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

class SportsCar:BasicCar
{
    

    private float accelerationTo100;
    private int weightKg;
    private GearboxType gearbox;

    internal SportsCar(float accelerationTo100, int weightKg, GearboxType gearbox,
    string model,int yearOfProduction,FuelType type,int horsePower, int availableRange,
    int seats, int? engineDisplacement, BodyType body, int maxRange)
    :base(seats,engineDisplacement,body,  model,yearOfProduction, type,horsePower,availableRange, maxRange)
    {
        this.accelerationTo100 = accelerationTo100;
        this.weightKg = weightKg;
        this.gearbox = gearbox;
    }
    
    internal float AccelerationTo100 => accelerationTo100;
    internal int WeightKg => weightKg;
    internal GearboxType Gearbox => gearbox;

    internal override void Drive(int km)
    {
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
        
    protected override void Refuel()
    {
        availableRange = maxRange;
        Console.WriteLine($"{model} был заправлен высокооктановым бензином");
    }

}