namespace ASP.NET_Core_The_Studio.Infrastructure.Extensions
{
    using ASP.NET_Core_The_Studio.Data;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static ASP.NET_Core_The_Studio.Areas.Admin.AdminConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var copedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = copedServices.ServiceProvider;

            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            MigrateDatabase(context);
            SeedAdministrator(serviceProvider);
            SeedBookRarity(context);
            SeedElectronicBooks(context, serviceProvider);
            SeedGeners(context);
            SeedRandomBookGeners(context);
            return app;
        }
        private static void MigrateDatabase(ApplicationDbContext context)
        {
            context.Database.Migrate();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                {
                    return;
                }

                await roleManager.CreateAsync(new IdentityRole { Name = AdministratorRoleName });

                const string adminEmail = "admin@test.com";
                const string adminPassword = "Admin123.";

                var userAdmin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(userAdmin, adminPassword);

                await userManager.AddToRoleAsync(userAdmin, AdministratorRoleName);
            })
                .GetAwaiter()
                .GetResult();
        }
        private static void SeedBookRarity(ApplicationDbContext context)
        {

            if (context.BookRarities.Any())
            {
                return;
            }

            context.BookRarities.AddRange(new[]
            {
                new BookRarity{Name = "Common"},
                new BookRarity{Name = "Rare"},
                new BookRarity{Name = "Limited"},
                new BookRarity{Name = "Event "},
                new BookRarity{Name = "Antique  "},
            });

            context.SaveChanges();
        }
        public static void SeedGeners(ApplicationDbContext context)
        {
            if (context.Geners.Any())
            {
                return;
            }

            context.Geners.AddRange(new[]
            {
                new Gener{Name = "Criminal"},
                new Gener{Name = "Horror"},
                new Gener{Name = "Thriller"},
                new Gener{Name = "Historical"},
                new Gener{Name = "Romance"},
                new Gener{Name = "Fantasy"},
                new Gener{Name = "Mystery"},
                new Gener{Name = "Drama"},
            });

            context.SaveChanges();
        }
        private static void SeedElectronicBooks(ApplicationDbContext context, IServiceProvider services)
        {
            if (context.ElectronicBooks.Any())
            {
                return;
            }

            var adminId = context.Users.Where(x => x.Email == "admin@test.com").FirstOrDefault().Id;
            var eBooks = new List<ElectronicBook>();
            var booksCount = 30;
            for (int i = 0; i < booksCount; i++)
            {
                var eBook = new ElectronicBook
                {
                    Author = SetRandomAuthor(),
                    CopySold = SetRandomCopySold(),
                    CreatedOn = DateTime.Now,
                    BookRarityId = SetRandomBookRarityId(context),
                    Pages = 0,
                    Price = SetRandomPriceInRange(1, 50),
                    BookCoverImage = null,
                    Data = null,
                    Title = SetRandomTitle(),
                    Description = "Lorem ipsumLorem ipsumLorem ipsumLorem ipsum",
                    UserId = adminId
                };
                eBooks.Add(eBook);
            }

            context.ElectronicBooks.AddRange(eBooks);
            context.SaveChanges();
        }
        private static void SeedRandomBookGeners(ApplicationDbContext context)
        {
            if (context.ElectronicBookGeners.Any())
            {
                return;
            }

            var books = context.ElectronicBooks.ToList();
            for (int i = 0; i < books.Count; i++)
            {
                var currentBook = books[i];
                var randomGener = SetRandomGener(context, currentBook);
                context.ElectronicBookGeners.Add(randomGener);
            }

            context.SaveChanges();

        }
        private static string SetRandomBookRarityId(ApplicationDbContext context)
        {
            var bookRarities = context.BookRarities.ToList();

            Random rnd = new Random();
            var randomBookRarityIndex = rnd.Next(0, bookRarities.Count);

            return bookRarities[randomBookRarityIndex].Id;
        }
        private static decimal SetRandomPriceInRange(int min, int max)
        {
            Random rnd = new Random();
            rnd.Next(min, max);

            return rnd.Next(min, max);
        }
        private static int SetRandomCopySold()
        {
            Random rnd = new Random();
            return rnd.Next(0, 1000);
        }
        private static string SetRandomAuthor()
        {
            string[] authors = {
                "Bojidar Ivanov",
                "Petko Ivanov",
                "Jordan Zankanakar",
                "Picha Dve",
                "Tiradjiq Ivanov",
                "Bojidar Vodafon",
            };
            Random rnd = new Random();
            var radnomIndex = rnd.Next(0, authors.Length);
            return authors[radnomIndex];
        }
        private static string SetRandomTitle()
        {
            string[] titles = {
                "Horror story",
                "Freakish",
                "Z-war",
                "The last of us",
                "Tell me acreepy thing",
            };

            Random rnd = new Random();
            var radnomIndex = rnd.Next(0, titles.Length);

            return titles[radnomIndex];
        }
        private static Gener GetRandomGener(ApplicationDbContext context)
        {
            var geners = context.Geners.ToList();

            Random rnd = new Random();
            var radnomIndex = rnd.Next(0, geners.Count);

            return geners[radnomIndex];
        }
        private static ElectronicBookGener SetRandomGener(ApplicationDbContext context, ElectronicBook book)
        {
            return new ElectronicBookGener
            {
                Gener = GetRandomGener(context),
                ElectronicBook = book
            };
        }
    }
}
