using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_GEO.Models.Dolly;
using Web_GEO.Models.Store;

namespace Web_GEO.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //CAR/Tayota
        public DbSet<Models.Cars.Tayota.TayotaModel> TayotaModels { get; set; }
        public DbSet<Models.Cars.Tayota.ColorModel> ColorModels { get; set; }
        public DbSet<Models.Cars.Tayota.ConfigurationModel> ConfigurationModels { get; set; }
        public DbSet<Models.Cars.Tayota.ConfigurationColorModel> ConfigurationColorModels { get; set; }

        //Dolly
        public DbSet<DollyModel> DollyModels { get; set; }
        public DbSet<Web_GEO.Models.Dolly.ColorModel> DollyColorModels { get; set; }
        public DbSet<StyleModel> StyleModels { get; set; }
        public DbSet<ImageModel> ImageModels { get; set; }
        //Store
        public DbSet<VendorModel> VendorModels { get; set; }
        public DbSet<CategoryModel> CategoryModels { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ActionModel> ActionModels { get; set; }

    }
}
