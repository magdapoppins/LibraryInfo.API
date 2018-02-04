using LibraryInfo.API.Entities;
using LibraryInfo.API.Models;
using LibraryInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
                return NotFound();
            }
            var library = _libraryInfoRepository.GetLibraryForCity(cityId, id);
            var libraryToReturn = new LibraryDto()
            {
                Name = library.Name,
                Id = library.Id,
                Contact = library.Contact
            };

            return Ok(libraryToReturn);
        }

        [HttpPost()]
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
            var libraryEntity = new Library()
            {
                Name = library.Name,
                Contact = library.Contact
            };
            libraryEntity.CityId = cityId;

            _libraryInfoRepository.AddLibrary(libraryEntity);
            _libraryInfoRepository.Save();

            return Created($"api/cities/{cityId}/libraries", libraryEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLibrary(int cityId, int id, [FromBody] LibraryForCreationDto library)
        {
            if (!_libraryInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var libraryEntity = new Library()
            {
                Name = library.Name,
                Contact = library.Contact,
                Id = id,
                CityId = cityId
            };

            _libraryInfoRepository.UpdateLibrary(libraryEntity);
            _libraryInfoRepository.Save();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateLibrary(int cityId, int id, [FromBody] JsonPatchDocument<LibraryForUpdateDto> patchDocument)
        {
            if (!_libraryInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }
            var libraryForPatching = new LibraryForUpdateDto();
            patchDocument.ApplyTo(libraryForPatching, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var libraryEntity = new Library()
            {
                Name = libraryForPatching.Name,
                Contact = libraryForPatching.Contact
            };
            _libraryInfoRepository.UpdateLibrary(libraryEntity);
            _libraryInfoRepository.Save();
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
            _libraryInfoRepository.Save();
            return NoContent();
        }
    }
}
