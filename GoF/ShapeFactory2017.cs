namespace ExamPrep
{
    public interface IShape
    {
        public void ShowShapeProps();
    }
    public class Rectangle(int length, int breadth) : IShape
    {
        public void ShowShapeProps()
        {
            Console.WriteLine(
                "\nRectangle props: Length = {0} & Breadth = {1}.\n", length, breadth
            );
        }
    }
    public class Square(int length) : IShape
    {
        public void ShowShapeProps()
        {
            Console.WriteLine(
                "Square props: Length = {0}.\n", length
            );
        }
    }
    public class Circle(double radius) : IShape
    {
        public void ShowShapeProps()
        {
            Console.WriteLine(
                "Circle props: Radius = {0}.\n", radius
            );
        }
    }
    public static class ShapeFactory
    {
        public static IShape GetShape(string type)
        {
            return type == "Rectangle"
                ? new Rectangle(15, 10)
                : type == "Square"
                ? new Square(5)
                : type == "Circle"
                ? new Circle(3.14)
                : throw new Exception("Invalid Shape type!");
        }
    }
    public static class ShapeFactoryDemo
    {
        public static void TestShapeFactory()
        {
            IShape rectangle = ShapeFactory.GetShape("Rectangle");
            IShape square = ShapeFactory.GetShape("Square");
            IShape circle = ShapeFactory.GetShape("Circle");

            rectangle.ShowShapeProps();
            square.ShowShapeProps();
            circle.ShowShapeProps();

            try
            {
                IShape invalidShape = ShapeFactory.GetShape("Invalid");
                invalidShape.ShowShapeProps();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}.", ex.Message);
            }
        }
    }
}