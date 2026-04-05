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
        this.radius = radius;

    }

    internal double X => x;
    internal double Y => y;
    internal double Radius=> radius;



    private double _area; // резервное поле
    private double _perimeter;




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
    get { if (_area == 0) // lazy computation
                _area = pi * radius * radius;
            return _area; } }
    

internal double Perimeter
{
    get {    if (_perimeter == 0)
                _perimeter = 2 * pi * radius;
            return _perimeter;
    
}}
    public override string ToString()
    {
        return $@"Радиус: {radius} Координаты центра окружности(x,y): ({x},{y})
        Area: {Area} Периметр: {Perimeter} ";
    }
}
