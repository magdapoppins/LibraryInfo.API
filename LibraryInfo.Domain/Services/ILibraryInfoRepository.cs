using LibraryInfo.API.Entities;
using System.Collections.Generic;

namespace LibraryInfo.API.Services
{
    public interface ILibraryInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int cityId);

        IEnumerable<Library> GetLibrariesForCity(int cityId);
        Library GetLibraryForCity(int libraryId);

        void UpdateCity(City city);
        void UpdateLibrary(Library library);

        void AddLibrary(Library library);
        void AddCity(City city);

        void DeleteLibrary(int cityId, int id);
        void DeleteCity(int id);

        bool CityExists(int cityId);
        bool LibraryExists(int libraryId);

        bool Save();
    }
}
