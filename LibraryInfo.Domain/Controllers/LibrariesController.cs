using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInfo.API.Controllers
{
    [Route("api/cities/{cityId}/libraries")]
    public class LibrariesController : Controller
    {
        private ILoggerFactory _logger;

        public LibrariesController(ILoggerFactory logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult GetCities()
        {

            return Ok();
        }
        //[HttpGet("{id}")]
        //[HttpPost()]
        //[HttpPut("{id}")]
        //[HttpPatch("{id}")]
        //[HttpDelete("{id}")]
    }
}
