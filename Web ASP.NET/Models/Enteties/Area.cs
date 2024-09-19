using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_ASP.NET.Models.Enteties
{
    public class Area
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        List<City>? Cities { get; set; } = new();
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country? Country { get; set; }
        public int? RegionCapitalId { get; set; }

        [ForeignKey("RegionCapitalId")]
        public City? RegionCapital { get; set; }
        List<AreaRegions>? AreaRegions { get; set; } = new();
    }
}
