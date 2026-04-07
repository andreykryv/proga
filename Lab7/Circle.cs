class Circle
{   const double pi = Math.PI;
    private double x;
    private double y;
    private double radius;

    internal Circle() : this(0,0,1){}
    
    internal Circle(double x,double y, double radius)
    {
        this.x = x;
        this.y = y;
         if (radius <= 0)
        {
             throw new ArgumentException("Радиус не может быть отрицательным.");
        }
        this.radius = radius;
       

    }

    internal double X => x;
    internal double Y => y;
    internal double Radius=> radius;

    


    public double this[int index]
    {get{switch (index) {
                case 0: return x;
                case 1: return y;
                case 2: return radius;
                default: throw new IndexOutOfRangeException("Индекс должен быть 0, 1 или 2.");
            }
        }
    set{switch (index) {
                case 0: x = value; break;
                case 1: y = value; break;
                case 2: radius = value; break;
                default: throw new IndexOutOfRangeException("Индекс должен быть 0, 1 или 2.");
            }
        }}

internal double Area
{
    get {   return pi * radius * radius; } }
    

internal double Perimeter
{
    get {   return 2 * pi * radius;
    
}}
    public override string ToString()
    {
        return $@"Радиус: {radius} Координаты центра окружности(x,y): ({x},{y})
        Area: {Area} Периметр: {Perimeter} ";
    }
public static bool operator >(Circle a, Circle b)
{
    return a.Area > b.Area;
}
public static bool operator <(Circle a,Circle b)
    {
        return a.Area < b.Area;
    }
public static bool operator ==(Circle a, Circle b)
{ return a.Area == b.Area;  }

public static bool operator !=(Circle a, Circle b)
{ return a.Area != b.Area;  }

 public static Circle operator ++(Circle c)
{
    return new Circle(c.X, c.Y, c.Radius+1);
}
 public static Circle operator --(Circle c)
{
    return new Circle(c.X, c.Y, c.Radius-1);
}
public static Circle operator -(Circle c)
{
    return new Circle(c.X, c.Y, c.Radius - 1);
}
public static Circle operator *(Circle c,double d)
{return new Circle (c.X,c.Y,c.Radius * d);}
public static Circle operator /(Circle c, double d)
{return new Circle (c.X,c.Y,c.Radius / d);}
public static bool operator false(Circle c)
{
    return c.X == 0 && c.Y == 0;
}
public static bool operator true(Circle c)
{
    return c.X != 0 || c.Y != 0;
}
public static implicit operator Circle(double d)
{
    return new Circle(0, 0, d);
}
public static explicit operator double(Circle d)
{
    return d.Radius;
}









}
