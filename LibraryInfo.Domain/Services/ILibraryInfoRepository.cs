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
        void UpdateCity(int cityId);
        bool CityExists(int cityId);
        bool Save();
    }
}
