using System.ComponentModel.DataAnnotations.Schema;

namespace Web_GEO.Models.Store
{
    public class ActionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EndTime { get; set; }
        public int DiscountCount { get; set; }
        public int DiscountPercentage { get; set; }
        public List<ProductModel> Products { get; set; } = new();
    }
}
