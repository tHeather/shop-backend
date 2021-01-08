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
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<FooterSettings> FooterSettings { get; set; }

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

            builder.Entity<Slider>().HasData(new Slider
            {
                Id = 1,
                FirstSlide = string.Empty,
                SecondSlide = string.Empty,
                ThirdSlide = string.Empty,
                FourthSlide = string.Empty,
                FifthSlide = string.Empty
            });

            builder.Entity<FooterSettings>().HasData(new FooterSettings
            {
                Id = 1,
                Email = string.Empty,
                PhoneNumber = string.Empty,
                Text = string.Empty,
                WeekendWorkingHours = string.Empty,
                WeekWorkingHours = string.Empty
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