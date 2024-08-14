using System.ComponentModel.DataAnnotations.Schema;

namespace Web_ASP.NET.Models.Enteties
{
    public class PostModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Slug { get; set; }

        // Внешний ключ для Category
        public int CategoryId { get; set; }

        // Навигационное свойство для связи с Category
        [ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; }

        public List<TagModel> Tags { get; set; }
            = new();
    }
}