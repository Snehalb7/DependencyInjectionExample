using DependencyInjectionExample.Model;
using Microsoft.EntityFrameworkCore;
using DependencyInjectionExample.Repository;

namespace DependencyInjectionExample.Services
{
    public class ProductService :IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<IEnumerable<Product>> GetAllProducts()=>_productRepository.GetAll();
        
        public Task<Product> GetProductById(int id) => _productRepository.GetProductById(id);

        public Task AddProduct(Product product) => _productRepository.AddProduct(product);
    }
}
