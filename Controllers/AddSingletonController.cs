using DependencyInjectionExample.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddSingletonController : ControllerBase
    {
        private readonly IGreetingSingleton _singleton;
        public AddSingletonController(IGreetingSingleton greetingSingleton)
        {
            _singleton = greetingSingleton;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _singleton.GetGreetings();
            return Ok(result);
        }
    }
}
