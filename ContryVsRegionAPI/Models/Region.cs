using ContryVsRegionAPI.Servics;

namespace ContryVsRegionAPI.Models
{
    public class Region
    {
       
        
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Code { get; set; }
        public virtual Country? Country { get; set; }
        public int CountryId { get; set; }
        
        
                   

        
    }
}
