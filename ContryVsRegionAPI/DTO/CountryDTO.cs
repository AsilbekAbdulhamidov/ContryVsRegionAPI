using Microsoft.AspNetCore.Http;

namespace ContryVsRegionAPI.DTO
{
    public class CountryDTO
    {
        public string? Title { get; set; }
        public string? ShortTitle { get; set; }
        public string? Code { get; set; }
        public string? ImageURl { get; set; }
       

    }
}
