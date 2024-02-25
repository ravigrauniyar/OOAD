namespace ExamPrep
{
    /// <summary>
    /// Represents a technician who performs website and API actions.
    /// </summary>
    public interface ITech
    {
        /// <summary>
        /// Performs website-related action.
        /// </summary>
        public void WebsiteAction();

        /// <summary>
        /// Performs API-related action.
        /// </summary>
        public void ApiAction();
    }

    /// <summary>
    /// Represents a developer who implements <see cref="ITech"/>.
    /// </summary>
    public class Developer : ITech
    {
        public void ApiAction()
        {
            Console.WriteLine("Building API...\n");
        }
        public void WebsiteAction()
        {
            Console.WriteLine("\nBuilding Website...\n");
        }
    }

    /// <summary>
    /// Represents a deployer who implements <see cref="ITech"/>.
    /// </summary>
    public class Deployer : ITech
    {
        public void ApiAction()
        {
            Console.WriteLine("Deploying API...\n");
        }
        public void WebsiteAction()
        {
            Console.WriteLine("Deploying Website...\n");
        }
    }

    /// <summary>
    /// Represents a factory to create instances of <see cref="ITech"/>.
    /// </summary>
    public static class TechFactory
    {
        /// <summary>
        /// Gets a technician instance based on the specified type.
        /// </summary>
        /// <returns>A technician instance.</returns>
        public static ITech GetTechnician(string type)
        {
            return type == "Developer"
                ? new Developer()
                : type == "Deployer"
                ? new Deployer()
                : throw new Exception("Invalid technician type!");
        }
    }

    /// <summary>
    /// Provides a method to test the functionality of the factory.
    /// </summary>
    public static class FactoryDemo
    {
        /// <summary>
        /// Tests the factory by creating technicians and performing actions.
        /// </summary>
        public static void TestFactory()
        {
            ITech developer = TechFactory.GetTechnician("Developer");
            developer.WebsiteAction();
            developer.ApiAction();

            ITech deployer = TechFactory.GetTechnician("Deployer");
            deployer.WebsiteAction();
            deployer.ApiAction();

            try
            {
                ITech invalidTypeTechnician = TechFactory.GetTechnician("Invalid Type");
                invalidTypeTechnician.WebsiteAction();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: {0}\n", exception.Message);
            }
        }
    }
}
