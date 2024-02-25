namespace ExamPrep
{
    public sealed class Singleton
    {
        private static Singleton? _singleton;
        private static readonly object resource = new();

        public Singleton()
        {
            Console.WriteLine("\nCreating Singleton class instance...\n");
        }
        public static Singleton GetSingleton
        {
            get
            {
                lock (resource)
                {
                    _singleton ??= new Singleton();
                    return _singleton;
                }
            }
        }
    }
    public static class SingletonDemo
    {
        public static void TestSingleton()
        {
            Singleton FirstSingleton = Singleton.GetSingleton;
            Singleton SecondSingleton = Singleton.GetSingleton;

            Console.WriteLine(
                (FirstSingleton == SecondSingleton ? "Same" : "Different")
                + " Singleton class instances.\n"
            );
        }
    }
}