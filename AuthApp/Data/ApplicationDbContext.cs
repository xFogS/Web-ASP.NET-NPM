﻿using AuthApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AvatarUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<AvatarUser> avatarUsers { get; set; }
    }
}
