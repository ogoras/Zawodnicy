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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zawodnik>()
                .HasOne(p => p.Trener)
                .WithMany();
        }

        public DbSet<Zawodnik> Zawodnik { get; set; }
        
        public DbSet<Trener> Trener { get; set; }
    }
}
