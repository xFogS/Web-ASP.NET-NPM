using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace Web_ASP.NET.Models.Enteties
{
    public class CityCityTypeLink
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        public int CityTypeId { get; set; }
        [ForeignKey("CityTypeId")]
        public CityType CityType { get; set; }
    }
}
