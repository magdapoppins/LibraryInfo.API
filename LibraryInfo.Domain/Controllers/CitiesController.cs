using AutoMapper;
using LibraryInfo.API.Models;
using LibraryInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private ILoggerFactory _logger;
        private ILibraryInfoRepository _libraryInfoRepository;

        public CitiesController(ILoggerFactory logger, ILibraryInfoRepository libraryInfoRepository)
        {
            _logger = logger;
            _libraryInfoRepository = libraryInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetCities()
        {
            var cityEntities = _libraryInfoRepository.GetCities();
            var citiesToReturn = new List<CityWithoutLibrariesDto>();
            foreach (var city in cityEntities)
            {
                var cityWithoutLibraries = new CityWithoutLibrariesDto()
                {
                    Name = city.Name,
                    Inhabitants = city.Inhabitants,
                    Id = city.Id
                };

                citiesToReturn.Add(cityWithoutLibraries);
            }
            return Ok(citiesToReturn);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            if (!_libraryInfoRepository.CityExists(id))
            {
                return NotFound();
            }
            var cityEntity = _libraryInfoRepository.GetCity(id);
            var cityToReturn = Mapper.Map<CityDto>(cityEntity);
            return Ok(cityToReturn);
        }
        //[HttpPost()]
        //[HttpPut("{id}")]
        //[HttpPatch("{id}")]
        //[HttpDelete("{id}")]
    }
}
