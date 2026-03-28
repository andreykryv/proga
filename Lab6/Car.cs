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


    protected abstract void Drive(int km);

    protected virtual void Refuel()
    {
        
    }
    protected void Rename(string model)
    {
        this. model = model;
    }
    
    internal string PrintInfo()
    {
        return $"автомобиль {model} {yearOfProduction} года выпуска. {type} cиловая установка мощностью {horsePower} л.c";
    }
}