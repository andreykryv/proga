using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

class SportsCar:BasicCar
{
    

    private float accelerationTo100;
    private int weightKg;
    private GearboxType gearbox;

    internal SportsCar(float accelerationTo100, int weightKg, GearboxType gearbox,
    string model,int yearOfProduction,FuelType type,int horsePower, int availableRange,
    int seats, float? engineDisplacement, BodyType body, int maxRange)
    :base(seats,engineDisplacement,body,  model,yearOfProduction, type,horsePower,availableRange, maxRange)
    {
        this.accelerationTo100 = accelerationTo100;
        this.weightKg = weightKg;
        this.gearbox = gearbox;
    }
    
    internal float AccelerationTo100 => accelerationTo100;
    internal int WeightKg => weightKg;
    internal GearboxType Gearbox => gearbox;

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
        Console.WriteLine($"{model} был заправлен высокооктановым бензином");
    }
    protected internal override string PrintInfo()
    {
        return $@"        Автомобиль {model} {yearOfProduction} года выпуска.[SPORT] 
        {type} cиловая установка мощностью {horsePower} л.c объёмом {engineDisplacement}л.
        В кузове {body} и вместимостью {seats} мест.
        Разгон 0-100: {accelerationTo100}  Вес: {weightKg} кг  КПП: {gearbox}
        Запас хода: {availableRange} км";}

}