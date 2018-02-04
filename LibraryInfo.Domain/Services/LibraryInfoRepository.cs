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
            return (_context.SaveChanges() == 1);
        }

        public void UpdateCity(City city)
        {
            var updateable = GetCity(city.Id);
            updateable.Name = city.Name;
            updateable.Inhabitants = city.Inhabitants;
        }

        public void UpdateLibrary(Library library)
        {
            var updateable = GetLibraryForCity(library.CityId, library.Id);
            updateable.Name = library.Name;
            updateable.Contact = library.Contact;

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
            var library = GetLibraryForCity(cityId, id);
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
    }
}
