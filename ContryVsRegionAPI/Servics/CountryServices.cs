using AutoMapper;
using ContryVsRegionAPI.DTO;
using ContryVsRegionAPI.Models;
using ContryVsRegionAPI.Repostory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.IO;

namespace ContryVsRegionAPI.Servics
{
    public class CountryServices : ICountryServics<Country,CountryDTO>
    {
        private readonly ICountryRepostory<Country> cnRep;
        private readonly IMapper mapper;


        public CountryServices(ICountryRepostory<Country> _cnRep, IMapper _mapper)
        {
            cnRep = _cnRep;
            mapper = _mapper;
        }

        public async Task Create(CountryDTO DTO)
        {
            var country = mapper.Map<Country>(DTO);
            
            //try
            //{
            //    var fil = DTO.fromFile;
            //    if (fil != null)
            //    {
            //        FileInfo fi = new FileInfo(fil.FileName);
            //        var newfilename = "image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
            //        var path = Path.Combine("", hostEnvironment.ContentRootPath + "/Images/" + newfilename);
            //        using (var stream = new FileStream(path, FileMode.Create))
            //        {
            //            fil.CopyTo(stream);
            //        }
            //        DTO.ImageURl = path;

                    
            //    }
            //}
            //catch (Exception ex)
            //{
               
            //}

            cnRep.Create(country).GetAwaiter().GetResult();
        }

        public async Task<bool> Delete(int id)
        {
            var res = await cnRep.Get(id);
            if(res is null)
            {
                return false;
            }
            else
            {
                await cnRep.Delete(res);
                return true;    
            }
        }

        public async Task<IEnumerable<Country>> Get()
        {
            return await cnRep.Get();
        }

        public async Task<Country> Get(int id)
        {
           return await cnRep.Get(id);
        }

        public async Task<Country> UpdateCountry(int id, CountryDTO DTO)
        {
            Country country = mapper.Map<Country>(DTO);
            country.Id = id;
            return await cnRep.Update(id, country);  
        }

        
        
    }
}
