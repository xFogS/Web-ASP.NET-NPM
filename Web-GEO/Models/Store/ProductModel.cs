using System.ComponentModel.DataAnnotations.Schema;

namespace Web_GEO.Models.Store
{
    public class ProductModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public VendorModel VendorModel { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel CategoryModel { get; set; }
        public List<ActionModel> Actions { get; set; } = new();
    }
}
