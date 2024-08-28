using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_ASP.NET.Models.Enteties;
using Web_ASP.NET.Models.Enteties.Store;

namespace Web_ASP.NET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Friend> Friends { get; set; }
        /*public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }*/
        public DbSet<Vendor> Vendors { get; set; }

        /*ONE TO MANY - MANY TO MANY*/
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<PostModel> Posts { get; set; }

        /*ONE TO MANY - MANY TO MANY - ONE TO MANY | AREA DESCRIPTION*/
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityType> CityTypes { get; set; }
        public DbSet<CityCityTypeLink> CityCityTypeLinks { get; set; }
        public DbSet<Street> Streets { get; set; }
    }
}
