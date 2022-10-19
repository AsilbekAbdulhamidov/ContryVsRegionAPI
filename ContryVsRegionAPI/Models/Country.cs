using System.ComponentModel.DataAnnotations;

namespace ContryVsRegionAPI.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? ShortTitle { get; set; }
        public string? Code { get; set; }
        public string? ImageURl { get; set; }
        public virtual IList<Region>? Regions { get; set; }

    }
}
