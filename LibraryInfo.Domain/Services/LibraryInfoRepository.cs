using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryInfo.API.Entities;

namespace LibraryInfo.API.Services
{
    public class LibraryInfoRepository : ILibraryInfoRepository
    {
        private LibraryInfoContext _context;

        public LibraryInfoRepository(LibraryInfoContext context)
        {
            _context = context;
        }

        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.ToList();
        }

        public City GetCity(int cityId)
        {
            return _context.Cities
                .FirstOrDefault(c => c.Id == cityId);
        }

        public IEnumerable<Library> GetLibrariesForCity(int cityId)
        {
            var libraries = _context.Libraries
                .Where(l => l.CityId == cityId);
            return libraries;
        }

        public Library GetLibraryForCity(int cityId, int libraryId)
        {
            var city = _context.Cities
                .FirstOrDefault(c => c.Id == cityId);
            var library = city.Libraries
                .FirstOrDefault(l => l.Id == libraryId);
            return library;

        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
