using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopBackend.BusinessLogic.Entities;
using System.Diagnostics.CodeAnalysis;


namespace ShopBackend.BusinessLogic.Database
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Theme> Themes { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext([NotNull] DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
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