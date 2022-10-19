using AutoMapper;
using AutoMapper.Execution;
using ContryVsRegionAPI.DTO;
using ContryVsRegionAPI.Models;
using ContryVsRegionAPI.Repostory;
using System.Drawing;
using Region = ContryVsRegionAPI.Models.Region;

namespace ContryVsRegionAPI.Servics
{
    public class RegionServices : ICountryServics<Region, RegionDTO>
    {
        private readonly ICountryRepostory<Region> _regRep;
        private readonly IMapper _mapper;

        public RegionServices(ICountryRepostory<Region> regRep, IMapper mapper)
        {
            _regRep = regRep;
            _mapper = mapper;
        }

        public async Task Create(RegionDTO DTO)
        {
             
            await _regRep.Create(_mapper.Map<Region>(DTO));
            
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _regRep.Get(id);
            if (res is null)
            {
                return false;
            }
            else
            {
                await _regRep.Delete(res);
                return true;
            }
        }

        public async Task<IEnumerable<Region>> Get()
        {
           return await _regRep.Get();
        }

        public async Task<Region> Get(int id)
        {
            return await _regRep.Get(id);
        }

        public async Task<Region> UpdateCountry(int id, RegionDTO DTO)
        {
            Region reg = _mapper.Map<Region>(DTO);
            reg.Id = id;
            return await _regRep.Update(id, reg);
            
        }
    }
}
