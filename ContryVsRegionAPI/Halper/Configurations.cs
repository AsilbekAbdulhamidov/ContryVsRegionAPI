using AutoMapper;
using ContryVsRegionAPI.DTO;
using ContryVsRegionAPI.Models;

namespace ContryVsRegionAPI.Halper
{
    public  class Configurations : Profile
    {
       public Configurations()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Region, RegionDTO>().ReverseMap();
   
        }
    }
}