namespace DependencyInjectionExample.Repository
{
    public class GreetingSingletonService :IGreetingSingleton
    {
      

        public readonly Guid serviceID;

        public GreetingSingletonService()
        {
            
            serviceID = Guid.NewGuid();
        }

        public string GetGreetings()
        {
            return $"Hello from Singleton Service with ID: {serviceID}";
        }
    }
}
