namespace ASP.NET_Core_The_Studio.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using ASP.NET_Core_The_Studio.Data.Data.Entities;

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

        public DbSet<ElectronicBookApplicationUser> ElectronicBookApplicationUsers { get; init; }

        public DbSet<Comment> Comments { get; init; }

        public DbSet<Reply> Replys { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Mapping table for books and geners
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

            //Mapping table for book and users
            modelBuilder.Entity<ElectronicBookApplicationUser>()
                .HasKey(bc => new { bc.ElectronicBookId, bc.ApplicationUserId });

            modelBuilder.Entity<ElectronicBookApplicationUser>()
                .HasOne(eb => eb.ElectronicBook)
                .WithMany(x => x.ApplicationUsers)
                .HasForeignKey(bc => bc.ElectronicBookId);

            modelBuilder.Entity<ElectronicBookApplicationUser>()
                .HasOne(eb => eb.ApplicationUser)
                .WithMany(x => x.ElectronicBooks)
                .HasForeignKey(bc => bc.ApplicationUserId);
        }
    }
}
