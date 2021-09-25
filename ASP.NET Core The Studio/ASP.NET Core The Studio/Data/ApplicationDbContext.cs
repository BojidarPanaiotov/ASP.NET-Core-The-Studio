namespace ASP.NET_Core_The_Studio.Data
{
    using ASP.NET_Core_The_Studio.Data.Entities;
    using Microsoft.AspNetCore.Identity;
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
        public DbSet<Gener> Geners { get; init; }
        public DbSet<ElectronicBookGener> ElectronicBookGeners { get; init; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ElectronicBookGener>()
                .HasKey(bc => new { bc.ElectronicBookId, bc.GenerId });

            modelBuilder.Entity<ElectronicBookGener>()
                .HasOne(eb => eb.ElectronicBook)
                .WithMany(x => x.ElectronicBookGener)
                .HasForeignKey(bc => bc.ElectronicBookId);

            modelBuilder.Entity<ElectronicBookGener>()
                .HasOne(g => g.Gener)
                .WithMany(x => x.ElectronicBookGener)
                .HasForeignKey(bc => bc.GenerId);
        }
    }
}
