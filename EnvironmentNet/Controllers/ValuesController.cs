using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EnvironmentNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Get()
        {
            return Ok($"Connection -> {_configuration.GetConnectionString("DefaultConnection")}");
        }
    }
}
