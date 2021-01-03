using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Entities.Enums;
using System.Diagnostics.CodeAnalysis;


namespace shop_backend.Database
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopSettings> ShopSettings { get; set; }

        public ApplicationDbContext([NotNull] DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShopSettings>().HasData(new ShopSettings {
                Id = 1,
                Logo = "",
                LeadingColor = "#002137",
                SecondaryColor = "#2137ff",
                TertiaryColor = "#ff2137",
                Currency = Currency.PLN
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Email = "admin@test.pl",
                NormalizedEmail = "ADMIN@TEST.PL",
                UserName = "admin@test.pl",
                NormalizedUserName = "ADMIN@TEST.PL",
                PasswordHash = "AQAAAAEAACcQAAAAEOYBeJPoRPDerQ65Eyj6pmLGeMTpwjMPKvtmAKI8bbn0eykfamwp5dlh+h2mlcTyBw==", //Qwerty!2345
            });

            base.OnModelCreating(builder);
        }
    }

}