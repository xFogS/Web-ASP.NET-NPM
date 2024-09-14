using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_GEO.Models.Cars.Tayota
{
    public class ColorModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public string RGB { get; set; } = null!;
        public string Code { get; set; } = null!;
        public List<ConfigurationColorModel> ConfColor { get; set; } = new();
    }
}
