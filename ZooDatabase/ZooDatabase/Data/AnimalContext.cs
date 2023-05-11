using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZooDatabase.Models;

namespace ZooDatabase.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext (DbContextOptions<AnimalContext> options)
            : base(options)
        {
        }

        public DbSet<ZooDatabase.Models.AnimalModel> AnimalModel { get; set; } = default!;
    }
}
