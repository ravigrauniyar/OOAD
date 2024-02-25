namespace ExamPrep.DesignPatterns
{
    /// <summary>
    /// Represents a singleton class that ensures only one instance is created.
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton? _singleton;
        private static readonly object _lock = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="Singleton"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is private to prevent external instantiation of the class.
        /// </remarks>
        private Singleton()
        {
            Console.WriteLine("\nCreating Singleton class instance...\n");
        }

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        /// <remarks>
        /// This method ensures that only one instance of the <see cref="Singleton"/> class is created.
        /// It uses double-checked locking to ensure thread safety:
        /// 1. It first checks if the instance is null without locking the object (_singleton).
        /// 2. If the instance is null, it locks the object to prevent multiple threads from creating separate instances concurrently.
        /// 3. Inside the lock, it checks again if the instance is null to ensure that only one instance is created.
        ///    If null, it creates a new instance of the Singleton class.
        ///    Otherwise, it returns the existing instance.
        /// </remarks>
        public static Singleton GetSingleton
        {
            get
            {
                lock (_lock)
                {
                    _singleton ??= new Singleton();
                    return _singleton;
                }
            }
        }
    }

    /// <summary>
    /// Provides a method to test the functionality of the singleton pattern.
    /// </summary>
    public static class SingletonDemo
    {
        /// <summary>
        /// Tests the singleton pattern by creating singleton instances.
        /// </summary>
        /// <remarks>
        /// Steps:
        /// 1. Obtain the first instance of the singleton using the <see cref="Singleton.GetSingleton"/> property.
        /// 2. Obtain the second instance of the singleton using the <see cref="Singleton.GetSingleton"/> property.
        /// 3. Compare the references of the first and second instances to determine if they are the same or different.
        /// </remarks>
        public static void TestSingleton()
        {
            Singleton firstSingleton = Singleton.GetSingleton;
            Singleton secondSingleton = Singleton.GetSingleton;

            Console.WriteLine(
                (firstSingleton == secondSingleton ? "Same" : "Different")
                + " Singleton class instances.\n"
            );
        }
    }
}
