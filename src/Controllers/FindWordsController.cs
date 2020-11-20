using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SpellingBee.Controllers
{
    [ApiController]
    public class FindWordsController : ControllerBase
    {
        private readonly ILogger<FindWordsController> _logger;
        private readonly IEnumerable<string> _words;

        public FindWordsController(ILogger<FindWordsController> logger, IEnumerable<string> words)
        {
            _logger = logger;
            _words = words;
        }

        [HttpGet]
        [Route("/FindWords")]
        public IEnumerable<string> Get([FromQuery]string possibleLetters, [FromQuery]string mustInclude)
        {
            // TODO: input validation
            return FindWords(possibleLetters.ToHashSet(), mustInclude[0]);
        }

        [HttpGet]
        [Route("/FindPanagrams")]
        public IEnumerable<string> FindPanagrams([FromQuery]string possibleLetters)
        {
            // TODO: input validation
            return FindPanagrams(possibleLetters.ToHashSet());
        }

        private IEnumerable<string> FindWords(ISet<char> possibleLetters, char mustInclude)
        {
            return this._words.Where(word =>
            {
                return word.Contains(mustInclude) && word.All(c => possibleLetters.Contains(c));
            });
        }

        private IEnumerable<string> FindPanagrams(ISet<char> possibleLetters)
        {
            return this._words.Where(word =>
            {
                return possibleLetters.All(c => word.Contains(c)) && word.All(c => possibleLetters.Contains(c));
            });
        }
    }
}
