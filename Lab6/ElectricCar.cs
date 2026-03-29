sealed class ElectricCar:BasicCar
{
    private int batteryCapacityKwh;
    private int kmPerKwh;


    internal ElectricCar(int batteryCapacityKwh,int kmPerKwh,string model,int yearOfProduction,FuelType type,int horsePower, 
    int seats, int? engineDisplacement, BodyType body, int maxRange)
    :base(seats,engineDisplacement,body,  model,yearOfProduction, type,horsePower,kmPerKwh * batteryCapacityKwh ,maxRange)
    {
        this.batteryCapacityKwh = batteryCapacityKwh;
        this.kmPerKwh = kmPerKwh;
        
    }

    internal int BatteryCapacityKwh => batteryCapacityKwh;
    internal int KmPerKwh => kmPerKwh;
    
    internal override void Drive(int km)
    {
        if (km <= availableRange)
        {
            availableRange -= km;
            batteryCapacityKwh -= km / kmPerKwh;
        }

        else
        {
           Console.WriteLine($"Машина проехала {availableRange} и {type} закончился");
           availableRange = 0;
           batteryCapacityKwh = 0;
        }
    }
    protected override void Refuel()
    {
        availableRange = maxRange;
        Console.WriteLine($",Батарея {model} была заряжена на 100%");
    }
}