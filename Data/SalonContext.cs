using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using salon.Models;

namespace Salon.Data
{
    public class SalonContext : DbContext
    {
        public SalonContext (DbContextOptions<SalonContext> options)
            : base(options)
        {
        }

        public DbSet<salon.Models.Angajat> Angajat { get; set; } = default!;

        public DbSet<salon.Models.Serviciu> Serviciu { get; set; }

        public DbSet<salon.Models.Client> Client { get; set; }

        public DbSet<salon.Models.Programare> Programare { get; set; }
    }
}
