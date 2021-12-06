using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Zawodnik> Zawodnik { get; set; }
        
        public DbSet<Trener> Trener { get; set; }
    }
}
