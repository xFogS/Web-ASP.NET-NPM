using System.ComponentModel.DataAnnotations.Schema;

namespace Web_GEO.Models.Dolly
{
    public class ImageModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? URL { get; set; }
        public List<DollyModel> DollyModels { get; set; } = new();
    }
}
