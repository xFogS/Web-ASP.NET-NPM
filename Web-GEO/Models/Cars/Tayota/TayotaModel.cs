using System.ComponentModel.DataAnnotations.Schema;

namespace Web_GEO.Models.Cars.Tayota
{
    public class TayotaModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ConfigurationModel> Configurations { get; set; } = new();
    }
}
