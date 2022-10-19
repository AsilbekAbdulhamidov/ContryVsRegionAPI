using ContryVsRegionAPI.DTO;
using ContryVsRegionAPI.Models;

namespace ContryVsRegionAPI.Servics
{
    public interface ICountryServics<T,U> where T : class
        where U : class
    {
        Task Create  (U  DTO);
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> UpdateCountry (int id,U DTO);
        Task<bool> Delete (int id);
    }
}
