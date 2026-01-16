namespace CalculArea
{
    public class Program
    {
        static void Main(string[] args)
        {

            Circle circle = new Circle(30);

            double resultCircle = circle.GetArea();
            Console.WriteLine($"Circle = {resultCircle}");

            Rectangle rectangle = new Rectangle(10,5);

            double resultRectangle = rectangle.GetArea();

            Console.WriteLine($"Rectangle = {resultRectangle}");
        }
    }
}