using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Testing_etc.Models.Cars
{
    public class ColorModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
       // public string? URL { get; set; }
        public string RGB { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
