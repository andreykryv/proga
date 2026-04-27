sealed class ElectricCar:BasicCar
{
    private int batteryCapacityKwh;
    private int kmPerKwh;


    internal ElectricCar(int batteryCapacityKwh,int kmPerKwh,string model,int yearOfProduction,FuelType type,int horsePower, 
    int seats, float? engineDisplacement, BodyType body, int maxRange)
    :base(seats,engineDisplacement,body,  model,yearOfProduction, type,horsePower,kmPerKwh * batteryCapacityKwh ,maxRange)
    {
        this.batteryCapacityKwh = batteryCapacityKwh;
        this.kmPerKwh = kmPerKwh;
        
    }

    internal int BatteryCapacityKwh => batteryCapacityKwh;
    internal int KmPerKwh => kmPerKwh;
    
    protected internal override void Drive(int km)
    {
    if (km < 0)
        throw new ArgumentException("Расстояние не может быть отрицательным.");
    if (availableRange == 0)
        throw new InvalidOperationException($"Батарея разрядилась, зарядите {model}.");
    
     if (km > availableRange)
        {
            int driven = availableRange;
            availableRange = 0;
            throw new InvalidOperationException(
                $"Проехали только {driven} км из {km} км. Батарея разрядилась, зарядите {model}.");
        }

        // Если заряда достаточно, просто вычитаем расстояние
        availableRange -= km;
    
}
    protected internal override void Refuel()
    {
        availableRange = maxRange;
        Console.WriteLine($"Батарея {model} была заряжена на 100%");
    }
    protected internal override string PrintInfo()
    {
        return $@"        Автомобиль {model} {yearOfProduction} года выпуска.[ELECTRIC]
        {type} cиловая установка мощностью {horsePower} л.c 
        В кузове {body} и вместимостью {seats} мест.
        C тяговой батареей на {batteryCapacityKwh} kwh
        Запас хода: {availableRange} км";
    }
}