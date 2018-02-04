using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInfo.API.Entities
{
    public class LibraryInfoContext : DbContext
    {
        public LibraryInfoContext(DbContextOptions<LibraryInfoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Library> Libraries { get; set; }
    }
}
