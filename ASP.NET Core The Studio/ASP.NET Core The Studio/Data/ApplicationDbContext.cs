namespace ASP.NET_Core_The_Studio.Data
{
    using ASP.NET_Core_The_Studio.Data.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; init; }
        public DbSet<ElectronicBook> ElectronicBooks { get; init; }
        public DbSet<BookRarity> BookRarities { get; init; }
        public DbSet<Test> Tests { get; init; }
    }
}
