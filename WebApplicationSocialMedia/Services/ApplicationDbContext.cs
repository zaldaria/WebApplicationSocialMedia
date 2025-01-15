using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using WebApplicationSocialMedia.Models;

namespace WebApplicationSocialMedia.Services
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole
            {
                Id = "1", 
                Name = "Admin",
                NormalizedName = "ADMIN" 
            };

            var user = new IdentityRole
            {
                Id = "2", 
                Name = "User",
                NormalizedName = "USER" 
            };


            builder.Entity<IdentityRole>().HasData(admin, user);

            
        }

    }
}
