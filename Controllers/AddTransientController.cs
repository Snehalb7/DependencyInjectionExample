using DependencyInjectionExample.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddTransientController : ControllerBase
    {
        private readonly IGreetingTransientService _instance;

        public AddTransientController(IGreetingTransientService greetingTransientService )
        {
            _instance = greetingTransientService;
        }
        [HttpGet]
        public IActionResult Get()
        {
           var result = _instance.GetGreetings();
            return Ok(result);
        }
    }
}
