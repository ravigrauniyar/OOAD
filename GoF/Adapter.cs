namespace ExamPrep
{
    public interface IClientRequest
    {
        public void ClientFetchData(int pageNumber, int pageSize);
    }
    public interface IAdaptee
    {
        public void AppFetchData(int pageNumber);
    }
    public class Adaptee : IAdaptee
    {
        public void AppFetchData(int pageNumber)
        {
            Console.WriteLine("Data for page number {0} returned!", pageNumber);
        }
    }
    public class Adapter(IAdaptee adaptee) : IClientRequest
    {
        private readonly IAdaptee _adaptee = adaptee;
        public void ClientFetchData(int pageNumber, int pageSize)
        {
            Console.WriteLine("\nPage Size: {0}.\n", pageSize);
            _adaptee.AppFetchData(pageNumber);
        }
    }
    public static class AdapterDemo
    {
        public static void TestAdapter()
        {
            IAdaptee adaptee = new Adaptee();
            Adapter adapter = new(adaptee);

            adapter.ClientFetchData(1, 10);
        }
    }
}