using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QoniacTest.IServices;
using QoniacTest.Service;
using System.Text.Json;

namespace QoniacTest.Controllers
{
    [ApiController]
    [Route("api/convert-money-numerics-to-words")]
    public class MoneyNumericsToWordController : ControllerBase
    {

        private readonly ILogger<MoneyNumericsToWordController> _logger;

        public MoneyNumericsToWordController(ILogger<MoneyNumericsToWordController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{ammount}")]
        public IActionResult Get(string ammount)
        {

            IMoneyNumericsToWordConverter converter = new MoneyNumericsToWordConverter();

            string _value = converter.ConvertDollarsAndCentsNumberToText(ammount);

            _logger.Log(logLevel: LogLevel.Information, _value);

            return Ok(JsonSerializer.Serialize(new { result = _value }));
        }
    }
}
