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
        public DbSet<PurchaseSettings> PurchaseSettings { get; set; }
        public DbSet<PersonalPickupBranch> PersonalPickupBranches { get; set; }
        public DbSet<Order> Order { get; set; }

        public ApplicationDbContext([NotNull] DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShopSettings>().HasData(new ShopSettings {
                Id = 1,
                Logo = "",
                NavbarColor = "#ffffff",
                BackgroundColor = "#ffffff",
                FooterColor = "#f1f1f1",
                SecondaryColor = "#f1f1f1",
                LeadingColor = "#02d463",
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

            builder.Entity<PurchaseSettings>().HasData(new PurchaseSettings
            {
                Id = 1,
                IsShippingAvaible = true,
                IsPersonalPickupAvaible = false,
                IsCashAvaible = false,
                IsDotpayAvaible = false,
                IsTransferAvaible = true,
                TransferNumber = "Testing transfer number"
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