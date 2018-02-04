using LibraryInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInfo.API.Services
{
    public interface ILibraryInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int cityId);

        IEnumerable<Library> GetLibrariesForCity(int cityId);
        Library GetLibraryForCity(int cityId, int libraryId);

        void UpdateCity(City city);
        void UpdateLibrary(Library library);

        void AddLibrary(Library library);
        void AddCity(City city);

        bool CityExists(int cityId);
        bool LibraryExists(int libraryId);

        bool Save();
    }
}
