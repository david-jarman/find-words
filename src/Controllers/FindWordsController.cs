using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SpellingBee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FindWordsController : ControllerBase
    {
        private readonly ILogger<FindWordsController> _logger;

        public FindWordsController(ILogger<FindWordsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get([FromQuery]string possibleLetters, [FromQuery]string mustInclude)
        {
            return $"Possible Letters: {possibleLetters}, Must include: {mustInclude}";
        }
    }
}
