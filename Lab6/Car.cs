//Porsche Macan
//BMW 3 Series
//Volkswagen Golf

abstract class Car
{
    protected string  model;
    protected int yearOfProduction; 

    protected FuelType type;     
    protected int horsePower; 
    protected int maxRange;
    protected internal int availableRange;

    internal Car(string model, int yearOfProduction, 
    FuelType type,int horsePower, int maxRange, int availableRange   )
    {
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.maxRange = maxRange;
        this.type = type;
        this.horsePower = horsePower;
        this.availableRange = availableRange;

    }
    
    internal string Model => model;
    internal int YearOfProduction => yearOfProduction;

    internal FuelType Type => type;
    internal int HorsePower => horsePower;
    internal int MaxRange => maxRange;
    internal int AvailableRange => availableRange;


    protected internal abstract void Drive(int km);

    protected internal virtual void Refuel()
    {
        availableRange = maxRange;
        Console.WriteLine($"{model} был заправлен");
    }
    protected internal void Rename(string model)
    {
        this. model = model;
    }
    
    protected internal virtual string PrintInfo()
    {
        return $"Автомобиль {model} {yearOfProduction} года выпуска. '\n' {type} cиловая установка мощностью {horsePower} л.c";
    }
}