using System.ComponentModel.DataAnnotations.Schema;

namespace Web_GEO.Models.Store
{
    public class VendorModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ProductModel> Products { get; set; } = new();
    }
}
