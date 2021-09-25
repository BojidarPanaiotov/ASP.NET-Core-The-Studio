namespace ASP.NET_Core_The_Studio.Infrastructure.Extensions
{
    using static ASP.NET_Core_The_Studio.Areas.Admin.AdminConstants;
    using ASP.NET_Core_The_Studio.Data;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;
    using System.Linq;

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
            SeedBookRarity(context, serviceProvider);
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
        private static void SeedBookRarity(ApplicationDbContext context, IServiceProvider services)
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

            context.SaveChangesAsync();
        }
    }
}
