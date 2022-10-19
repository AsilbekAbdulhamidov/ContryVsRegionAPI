using ContryVsRegionAPI.DTO;
using ContryVsRegionAPI.Models;
using ContryVsRegionAPI.Servics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContryVsRegionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly ICountryServics<Region, RegionDTO> _servics;

        public RegionController(ICountryServics<Region, RegionDTO> regSrv)
        {
            _servics = regSrv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _servics.Get());

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] RegionDTO DTO)
        {
            await _servics.Create(DTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _servics.Delete(id));

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RegionDTO DTO)
        {


            return Ok(await _servics.UpdateCountry(id, DTO));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _servics.Get(id));
        }
    }
}
