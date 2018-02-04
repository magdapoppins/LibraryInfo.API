using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInfo.API.Models
{
    public class CityForUpdateDto
    {
        [Required(ErrorMessage = "Provide a name for the city")]
        public string Name { get; set; }

        public int Inhabitants { get; set; }
    }
}
