using ExamPrep.Interfaces;
namespace ExamPrep.DesignPatterns
{
    /// <summary>
    /// Represents the implementation of <see cref="IAdaptee"/>.
    /// </summary>
    public class Adaptee : IAdaptee
    {
        public void AppFetchData(int pageNumber)
        {
            Console.WriteLine("Data for page number {0} returned!", pageNumber);
        }
    }

    /// <summary>
    /// Represents an adapter that adapts <see cref="IAdaptee"/> to <see cref="IClientRequest"/>.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Adapter"/> class with an adaptee.
    /// </remarks>
    public class Adapter(IAdaptee adaptee) : IClientRequest
    {
        private readonly IAdaptee _adaptee = adaptee;
        public void ClientFetchData(int pageNumber, int pageSize)
        {
            Console.WriteLine("\nPage Size: {0}.\n", pageSize);
            _adaptee.AppFetchData(pageNumber);
        }
    }

    /// <summary>
    /// Provides a method to test the functionality of the adapter.
    /// </summary>
    public static class AdapterDemo
    {
        /// <summary>
        /// Tests the adapter by fetching data.
        /// </summary>
        public static void TestAdapter()
        {
            IAdaptee adaptee = new Adaptee();
            Adapter adapter = new(adaptee);

            adapter.ClientFetchData(1, 10);
        }
    }
}
