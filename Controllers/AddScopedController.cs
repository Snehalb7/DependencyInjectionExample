using DependencyInjectionExample.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddScopedController : ControllerBase
    {
        private readonly IGreetingScoped _scoped;

        public AddScopedController(IGreetingScoped greetingScoped)
        {
            _scoped = greetingScoped;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _scoped.GetGreetings();
            return Ok(result);
        }   
    }
}
