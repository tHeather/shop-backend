using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using System.Diagnostics.CodeAnalysis;


namespace shop_backend.Database
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext([NotNull] DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }

}