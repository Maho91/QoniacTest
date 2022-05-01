using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QoniacExercise.Domain.ResponseModels;
using QoniacExercise.IServices;
using QoniacExercise.Service;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;

namespace QoniacExercise.Controllers
{
    [ApiController]
    [Route("api/convert-money-numerics-to-words")]
    public class CurrencyNumericsToWordController : ControllerBase
    {

        private readonly ILogger<CurrencyNumericsToWordController> _logger;

        public CurrencyNumericsToWordController(ILogger<CurrencyNumericsToWordController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{amount}")]
        [SwaggerOperation(Summary = "Convert currency from numirc to words")]
        [ProducesResponseType(200, Type = typeof(SuccessResponse))]
        [ProducesResponseType(400, Type = typeof(FailedResponse))]
        public IActionResult Convert([FromRoute] string amount)
        {

            ICurrencyNumericsToWordConverter converter = new CurrencyNumericsToWordConverter();
            string _value = converter.Convert(amount);
            _logger.Log(logLevel: LogLevel.Information, _value);
            return Ok(JsonSerializer.Serialize(new SuccessResponse { Result = _value }));
        }
    }
}
