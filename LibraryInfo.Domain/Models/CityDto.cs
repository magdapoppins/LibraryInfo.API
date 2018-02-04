using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInfo.API.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Inhabitants { get; set; }
        public ICollection<LibraryDto> Libraries { get; set; } = new List<LibraryDto>();
    }
}
