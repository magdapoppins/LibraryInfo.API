using AutoMapper;
using LibraryInfo.API.Entities;
using LibraryInfo.API.Models;
using LibraryInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace LibraryInfo.API.Controllers
{
    [Route("api/cities/{cityId}/libraries")]
    public class LibrariesController : Controller
    {
        private ILoggerFactory _logger;
        private ILibraryInfoRepository _libraryInfoRepository;

        public LibrariesController(ILoggerFactory logger, ILibraryInfoRepository libraryInfoRepository)
        {
            _logger = logger;
            _libraryInfoRepository = libraryInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetLibraries(int cityId)
        {
            if (!_libraryInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }
            var libraryEntities = _libraryInfoRepository.GetLibrariesForCity(cityId);
            var returnableLibraries = new List<LibraryDto>();
            foreach (var library in libraryEntities)
            {
                var addableLibrary = new LibraryDto()
                {
                    Name = library.Name,
                    Contact = library.Contact,
                    Id = library.Id
                };

                returnableLibraries.Add(addableLibrary);
            }
            return Ok(returnableLibraries);
        }

        [HttpGet("{id}")]
        public IActionResult GetLibrary(int cityId, int id)
        {
            if (!_libraryInfoRepository.CityExists(cityId))
            {
                _logger.
                return NotFound();
            }
            var library = _libraryInfoRepository.GetLibraryForCity(id);
            var libraryToReturn = new LibraryDto()
            {
                Name = library.Name,
                Id = library.Id,
                Contact = library.Contact
            };

            return Ok(libraryToReturn);
        }

        [HttpPost(Name = "AddLibrary")]
        public IActionResult AddLibrary(int cityId, [FromBody] LibraryForCreationDto library)
        {
            if (!_libraryInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var libraryEntity = Mapper.Map<Library>(library);

            libraryEntity.CityId = cityId;
            libraryEntity.City = _libraryInfoRepository.GetCity(cityId);

            _libraryInfoRepository.AddLibrary(libraryEntity);

            if (!_libraryInfoRepository.Save())
            {
                return StatusCode(500, "An error occurred when handling your request.");
            }

            var libraryToReturn = Mapper.Map<LibraryDto>(libraryEntity);

            return CreatedAtRoute("AddLibrary", new {cityId = cityId, id = libraryToReturn.Id}, libraryToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLibrary(int cityId, int id, [FromBody] LibraryForCreationDto library)
        {
            if (!_libraryInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }
            var cityFromDb = _libraryInfoRepository.GetCity(cityId);
            var libraryFromDb = cityFromDb.Libraries.FirstOrDefault(l => l.Id == id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var libraryEntity = Mapper.Map<Library>(library);
            // Create a mapping and save changes
            Mapper.Map(library, libraryFromDb);

            if (!_libraryInfoRepository.Save())
            {
                return StatusCode(500, "An error occurred when handling your request.");
            }
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateLibrary(int cityId, int id, [FromBody] JsonPatchDocument<LibraryForUpdateDto> patchDocument)
        {
            if (!_libraryInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }
            var cityFromDb = _libraryInfoRepository.GetCity(cityId);
            var libraryFromDb = cityFromDb.Libraries.FirstOrDefault(l => l.Id == id);
            var libraryForPatching = new LibraryForUpdateDto();
            patchDocument.ApplyTo(libraryForPatching, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var libraryEntity = Mapper.Map<Library>(libraryForPatching);
            //_libraryInfoRepository.UpdateLibrary(libraryEntity);

            Mapper.Map(libraryForPatching, libraryFromDb);

            if (!_libraryInfoRepository.Save())
            {
                return StatusCode(500, "An error occurred when handling your request.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLibrary(int cityId, int id)
        {
            if (!_libraryInfoRepository.LibraryExists(id))
            {
                return NotFound();
            }
            _libraryInfoRepository.DeleteLibrary(cityId, id);

            if (!_libraryInfoRepository.Save())
            {
                return StatusCode(500, "An error occurred when handling your request.");
            }
            return NoContent();
        }
    }
}
