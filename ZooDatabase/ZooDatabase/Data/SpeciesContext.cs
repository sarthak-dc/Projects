using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZooDatabase.Models;

namespace ZooDatabase.Data
{
    public class SpeciesContext : DbContext
    {
        public SpeciesContext (DbContextOptions<SpeciesContext> options)
            : base(options)
        {
        }

        public DbSet<ZooDatabase.Models.SpeciesModel> SpeciesModel { get; set; } = default!;
    }
}
