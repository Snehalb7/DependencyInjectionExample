using DependencyInjectionExample.Model;
namespace DependencyInjectionExample.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product product);
    }       
}
