using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Wizitka.Models
{
    public class PerformanceContext : DbContext
    {
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public PerformanceContext() : base("DefaultConnection")
         { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Performance>().HasMany(c => c.Actors)
                .WithMany(s => s.Performances)
                .Map(t => t.MapLeftKey("PerformanceId")
                .MapRightKey("ActorsId")
                .ToTable("PerformanceActors"));
        }
    }
}