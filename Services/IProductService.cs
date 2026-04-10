using DependencyInjectionExample.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProductById(int id);
        public Task AddProduct(Product product);
    }
}
