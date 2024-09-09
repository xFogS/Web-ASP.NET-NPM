using System.ComponentModel.DataAnnotations.Schema;

namespace Web_GEO.Models.Dolly
{
    public class ColorModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<DollyModel> DollyModels { get; set; } = new();
    }
}
