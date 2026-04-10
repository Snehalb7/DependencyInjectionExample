namespace DependencyInjectionExample.Repository
{
    public class GreetingsTransientService : IGreetingTransientService
    {
        public readonly Guid serviceID;

        public GreetingsTransientService()
        {
            serviceID = Guid.NewGuid();
        }
        public string GetGreetings()
        {
            return $"Hello from Transient Service with ID: {serviceID}";
        }
    }
}
