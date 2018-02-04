using AutoMapper;
using LibraryInfo.API.Entities;
using LibraryInfo.API.Models;
using LibraryInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
            var libraryEntities = _libraryInfoRepository.GetLibrariesForCity(id);
            var librariesToReturn = Mapper.Map<List<LibraryDto>>(libraryEntities);
            cityToReturn.Libraries = librariesToReturn;
            return Ok(cityToReturn);
        }

        [HttpPost()]
        public IActionResult AddCity([FromBody] CityForCreationDto city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cityEntity = new City()
            {
                Name = city.Name,
                Inhabitants = city.Inhabitants
            };
            _libraryInfoRepository.AddCity(cityEntity);
            return Created($"api/cities", cityEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] CityForUpdateDto city)
        {
            if (!_libraryInfoRepository.CityExists(id))
            {
                return NotFound();
            }
            var cityEntity = new City()
            {
                Name = city.Name,
                Inhabitants = city.Inhabitants,
                Id = id
            };
            _libraryInfoRepository.UpdateCity(cityEntity);
            _libraryInfoRepository.Save();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateCity(int id, [FromBody] JsonPatchDocument<CityForUpdateDto> patchDocument)
        {
            if (!_libraryInfoRepository.CityExists(id))
            {
                return NotFound();
            }
            var cityForPatching = new CityForUpdateDto();
            patchDocument.ApplyTo(cityForPatching, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cityEntity = new City()
            {
                Name = cityForPatching.Name,
                Inhabitants = cityForPatching.Inhabitants,
                Id = id
            };
            _libraryInfoRepository.UpdateCity(cityEntity);
            _libraryInfoRepository.Save();
            return NoContent();

            //[HttpDelete("{id}")]
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            if (!_libraryInfoRepository.CityExists(id))
            {
                return NotFound();
            }
            _libraryInfoRepository.DeleteCity(id);
            _libraryInfoRepository.Save();
            return NoContent();
        }
    }
}
