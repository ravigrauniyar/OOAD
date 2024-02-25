namespace ExamPrep
{
    /// <summary>
    /// Represents a shape with a method to show its properties.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Displays the properties of the shape.
        /// </summary>
        public void ShowShapeProps();
    }

    /// <summary>
    /// Represents a rectangle shape.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Rectangle"/> class with the specified length and breadth.
    /// </remarks>
    public class Rectangle(int length, int breadth) : IShape
    {
        private readonly int _length = length;
        private readonly int _breadth = breadth;

        public void ShowShapeProps()
        {
            Console.WriteLine(
                "\nRectangle props: Length = {0} & Breadth = {1}.\n", _length, _breadth
            );
        }
    }

    /// <summary>
    /// Represents a square shape.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Square"/> class with the specified length.
    /// </remarks>
    public class Square(int length) : IShape
    {
        private readonly int _length = length;

        public void ShowShapeProps()
        {
            Console.WriteLine(
                "Square props: Length = {0}.\n", _length
            );
        }
    }

    /// <summary>
    /// Represents a circle shape.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Circle"/> class with the specified radius.
    /// </remarks>
    public class Circle(double radius) : IShape
    {
        private readonly double _radius = radius;

        public void ShowShapeProps()
        {
            Console.WriteLine(
                "Circle props: Radius = {0}.\n", _radius
            );
        }
    }

    /// <summary>
    /// Represents a factory to create instances of <see cref="IShape"/>.
    /// </summary>
    public static class ShapeFactory
    {
        /// <summary>
        /// Gets a shape instance based on the specified type.
        /// </summary>
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

    /// <summary>
    /// Provides a method to test the functionality of the shape factory.
    /// </summary>
    public static class ShapeFactoryDemo
    {
        /// <summary>
        /// Tests the shape factory by creating shapes and displaying their properties.
        /// </summary>
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
