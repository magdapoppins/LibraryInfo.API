using System.Collections.Generic;
using System.Linq;
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

        public bool LibraryExists(int libraryId)
        {
            return _context.Libraries.Any(l => l.Id == libraryId);
        }


        public City GetCity(int cityId)
        {
            return _context.Cities
                .FirstOrDefault(c => c.Id == cityId);
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.ToList();
        }


        public Library GetLibraryForCity(int libraryId)
        {
            var library = _context.Libraries
                .FirstOrDefault(l => l.Id == libraryId);
            return library;
        }

        public IEnumerable<Library> GetLibrariesForCity(int cityId)
        {
            var libraries = _context.Libraries
                .Where(l => l.CityId == cityId);
            return libraries;
        }


        public void AddLibrary(Library library)
        {
            _context.Libraries.Add(library);
        }

        public void AddCity(City city)
        {
            _context.Cities.Add(city);
        }


        public void DeleteLibrary (int cityId, int id)
        {
            var library = GetLibraryForCity(id);
            _context.Libraries.Remove(library);
        }

        public void DeleteCity (int id)
        {
            var city = GetCity(id);
            var librariesOfCity = _context.Libraries
                .Where(l => l.CityId == id);
            _context.Libraries.RemoveRange(librariesOfCity);
            _context.Cities.Remove(city);
        }


        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
