using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PolisArkiv.Models;

namespace PoliceArchive.Data
{
    public class PoliceArchiveContext : DbContext
    {
        public PoliceArchiveContext (DbContextOptions<PoliceArchiveContext> options)
            : base(options)
        {
        }

        public DbSet<PolisArkiv.Models.Policeman> Policeman { get; set; } = default!;
        public DbSet<PolisArkiv.Models.Evidence> Evidence { get; set; } = default!;
        public DbSet<PolisArkiv.Models.ArchiveBox> ArchiveBox { get; set; } = default!;
    }
}
