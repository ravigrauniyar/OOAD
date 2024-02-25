namespace ExamPrep
{
    public interface ITech
    {
        public void WebsiteAction();
        public void ApiAction();
    }
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
    public static class TechFactory
    {
        public static ITech GetTechnician(string type)
        {
            return type == "Developer"
                ? new Developer()
                : type == "Deployer"
                ? new Deployer()
                : throw new Exception("Invalid technician type!");
        }
    }
    public static class FactoryDemo
    {
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