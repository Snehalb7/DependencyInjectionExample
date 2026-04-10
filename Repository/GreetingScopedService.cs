namespace DependencyInjectionExample.Repository
{
    public class GreetingScopedService :IGreetingScoped
    {
        public readonly Guid serviceID;
        public GreetingScopedService()
        {
            serviceID = Guid.NewGuid();
        }
        public string GetGreetings()
        {
            return $"Hello from Scoped Service with ID: {serviceID}";
        }
    }
}
