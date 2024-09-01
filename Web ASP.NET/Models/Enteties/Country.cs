using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Web_ASP.NET.Models.Enteties
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CapitalId { get; set; }
        [ForeignKey("CapitalId")]
        public City? Capital { get; set; }
        List<Area>? Areas { get; set; } = new();
    }
}
