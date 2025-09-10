using InvestChecker.Application.UseCases.News.Commands.SyncNews;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvestChecker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController(IMediator mediator) : ControllerBase
    {

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var command = new SyncNewsCommand();
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
