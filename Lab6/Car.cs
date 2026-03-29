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

    internal Car(string model, int yearOfProduction, 
    FuelType type,int horsePower, int maxRange   )
    {
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.maxRange = maxRange;
        this.type = type;
        this.horsePower = horsePower;

    }
    
    internal string Model => model;
    internal int YearOfProduction => yearOfProduction;

    internal FuelType Type => type;
    internal int HorsePower => horsePower;
    internal int MaxRange => maxRange;


    protected internal abstract void Drive(int km);

    protected internal virtual void Refuel()
    {
        
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