using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInfo.API.Models
{
    public class CityWithoutLibrariesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Inhabitants { get; set; }
    }
}
