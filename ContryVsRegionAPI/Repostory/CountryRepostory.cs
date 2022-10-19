using AutoMapper;
using ContryVsRegionAPI.Contex;
using ContryVsRegionAPI.DTO;
using ContryVsRegionAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace ContryVsRegionAPI.Repostory
{
    public class CountryRepostory : ICountryRepostory<Country>
    {
        private readonly AppDbContext db;

        public CountryRepostory(AppDbContext _db)
        {
            db = _db;
        }

        public async Task Create(Country country)
        {
            await db.AddAsync(country);
            await db.SaveChangesAsync();
        }

        public  async Task Delete(Country country )
        {
            db.Countries.Remove(country);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> Get()
        {
            return await db.Countries.Include(p=>p.Regions).ToListAsync();
        }

        public async Task<Country> Get(int id)
        {
            return await db.Countries.FindAsync(id);
        }

        public async Task<Country> Update(int id, Country country)
        {
            var current = await db.Countries.FindAsync(id);
            if (current == null)
            {
                await db.Countries.AddAsync(country);
               
            }
            else
            {
                db.Entry(current).CurrentValues.SetValues(country);
            }
            await db.SaveChangesAsync();
            return country;

            


        }

        
    }
}
