using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInfo.API.Models
{
    public class LibraryForCreationDto
    {
        [Required(ErrorMessage = "Provide a name for the library")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide a contact for the library")]
        [MaxLength(50)]
        public string Contact { get; set; }
    }
}
