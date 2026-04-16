using DependencyInjectionExample.Model;
using DependencyInjectionExample.Repository;
using DependencyInjectionExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IGreetingTransientService _t1;

        public ProductsController(IProductService service,IGreetingTransientService t)
           
        {
            _productService=service;
            _t1 = t;

        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() => Ok(await _productService.GetAllProducts());

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _productService.AddProduct(product);
            return Ok(product);
        }

        [HttpGet]
        [Route("TestCutomMiddleware")]
        public IActionResult TestMiddleware()
        {
            throw new Exception("This is a test exception from the ProductsController.");
        }
    }
}
