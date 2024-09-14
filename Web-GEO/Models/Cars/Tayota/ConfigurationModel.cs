using System.ComponentModel.DataAnnotations.Schema;

namespace Web_GEO.Models.Cars.Tayota
{
    public class ConfigurationModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public TayotaModel? TayotaModel { get; set; }
        public List<ConfigurationColorModel> ConfColor { get; set; } = new();
    }
}
