using ContryVsRegionAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ContryVsRegionAPI.Contex
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country>? Countries { get; set; }
        public DbSet<Region>? Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Region>().
                HasOne(p => p.Country).
                WithMany(p => p.Regions).
                HasForeignKey(p => p.CountryId);

        }
    }
}
