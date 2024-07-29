using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_ASP.NET.Models.Enteties;

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
    }
}
