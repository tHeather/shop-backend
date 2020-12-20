using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using System.Diagnostics.CodeAnalysis;


namespace shop_backend.Database
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Theme> Themes { get; set; }

        public ApplicationDbContext([NotNull] DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Theme>().HasData(new Theme {
                Id = 1,
                LeadingColor = "#002137",
                SecondaryColor = "#2137ff",
                TertiaryColor = "#ff2137"
            });

            base.OnModelCreating(builder);
        }
    }

}