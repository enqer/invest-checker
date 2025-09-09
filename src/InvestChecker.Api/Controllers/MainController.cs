using Microsoft.AspNetCore.Mvc;

namespace InvestChecker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            return Ok("test");
        }
    }
}
