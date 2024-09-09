using System.ComponentModel.DataAnnotations.Schema;

namespace Web_GEO.Models.Dolly
{
    public class DollyModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ColorId { get; set; }
        [ForeignKey("ColorId")]
        public ColorModel? ColorModel { get; set; }
        public int? StyleId { get; set; }
        [ForeignKey("StyleId")]
        public StyleModel? StyleModel { get; set; }
        public int? ImageId { get; set; }
        [ForeignKey("ImageId")]
        public ImageModel? ImageModel { get; set; }
    }
}
