
interface IShape
{
   public int Area();
}
class Rectangle: IShape
{
    protected int width, height;

    public void SetWidth(int width) { this.width = width; }
    public void SetHeight(int height) { this.height = height; }

    public int Area() { return width * height; }
}

class Square : IShape
{
    public int Side;
    public void SetWidth(int side)
    {
        Side = side;
    }

    public int Area() { return Side * Side; }
}

class Shapes
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Implementing SOLID Principles");

        //Rectangle Area
        Rectangle rect = new Rectangle();
        rect.SetWidth(50);
        rect.SetHeight(30);
        Console.WriteLine($"The Area of Rectangle is {rect.Area()} with height: 50 and width : 30");

        //Square Area
        Square sq = new Square();
        sq.SetWidth(50);
        Console.WriteLine($"\nThe Area of Rectangle is {sq.Area()} with side: 50");





    }
}
