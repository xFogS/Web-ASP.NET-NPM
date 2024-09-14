using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace Web_GEO.Models.Cars.Tayota
{
    public class ConfigurationColorModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public ColorModel? ColorModel { get; set; }
        public int ConfigurationId { get; set; }
        [ForeignKey("ConfigurationId")]
        public ConfigurationModel? ConfigurationModel { get; set; }
        public string? CarImageUrl { get; set; }
    }
}
