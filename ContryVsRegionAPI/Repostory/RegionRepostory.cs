using ContryVsRegionAPI.Contex;
using ContryVsRegionAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ContryVsRegionAPI.Repostory
{
    public class RegionRepostory : ICountryRepostory<Region>
    {
        private readonly AppDbContext _db;

        public RegionRepostory(AppDbContext db)
        {
            _db = db;
        }

        public async Task Create(Region region)
        {
            await _db.Regions.AddAsync(region); 
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Region region)
        {
            _db.Regions.Remove(region);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Region>> Get()
        {
            return await _db.Regions.ToListAsync();
        }

        public async Task<Region> Get(int id)
        {
            return await _db.Regions.FindAsync(id);
        }

        public async Task<Region> Update(int id, Region region)
        {
            var current = await _db.Regions.FindAsync(id);
            if (current == null)
            {
                await _db.Regions.AddAsync(region);

            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(region);
            }
            await _db.SaveChangesAsync();
            return region;
        }
    }
}
