using System.ComponentModel.DataAnnotations.Schema;

namespace Web_ASP.NET.Models.Enteties
{
    public class AreaRegions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? AreaId { get; set; }
        [ForeignKey("AreaId")]
        public Area? Area { get; set; }
        public int? RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region? Region { get; set; }
    }
}
