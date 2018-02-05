using System.Collections.Generic;

namespace LibraryInfo.API.Models
{
    public abstract class LinkedResourceDto
    {
        public List<LinkDto> Links { get; set; }
    }
}
