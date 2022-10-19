using ContryVsRegionAPI.DTO;
using ContryVsRegionAPI.Models;

namespace ContryVsRegionAPI.Repostory
{
    public interface ICountryRepostory<T> where T : class
    {
        Task<IEnumerable<T>> Get();  // All country
        Task<T> Get(int id);
        Task Create  (T country);  
        Task<T> Update (int _old,T _new);
        Task Delete ( T country);

        //CRUD
        //cread 
        //read 
        //update
        //delete

    }
}
