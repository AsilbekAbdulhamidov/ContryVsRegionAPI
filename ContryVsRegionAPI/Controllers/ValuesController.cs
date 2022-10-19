using ContryVsRegionAPI.Models;
using ContryVsRegionAPI.Servics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContryVsRegionAPI.DTO;
using ContryVsRegionAPI.Repostory;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;

namespace ContryVsRegionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ValuesController : ControllerBase
    {
        private readonly ICountryServics<Country, CountryDTO> _servics;

        public ValuesController(ICountryServics<Country, CountryDTO> servics)
        {
            _servics = servics;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _servics.Get());
            
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryDTO countryDTO)
        {
            return Ok(_servics.Create(countryDTO));
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            return Ok(await _servics.Delete(id));  

        }
        [HttpPut ("{id}")]
        public async Task<IActionResult> Update ( int id, CountryDTO countryDTO)
        {
            return Ok(await _servics.UpdateCountry(id,countryDTO) );
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id)
        {
            return Ok(await _servics.Get(id));  
        }


       // region






























        //[HttpPost("Region")]
        //public async Task<IActionResult> PostREg([FromForm] RegionDTO countryDTO)
        //{
        //    return Ok(_regSer.Create(countryDTO));
        //}

        //[HttpDelete("{id Region}") ]
        //public async Task<IActionResult> DeleteReg(int id)
        //{
        //    return Ok(await _regSer.Delete(id));

        //}
        //[HttpPut("{id Region}")]
        //public async Task<IActionResult> UpdateReg(int id, [FromBody] RegionDTO countryDTO)
        //{


        //    return Ok(await _regSer.UpdateCountry(id, countryDTO));
        //}

        //[HttpGet("{id Region}")]
        //public async Task<IActionResult> GetReg(int id)
        //{
        //    return Ok(await _regSer.Get(id));
        //}
    }
}
