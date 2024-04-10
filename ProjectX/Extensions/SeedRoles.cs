using Microsoft.AspNetCore.Identity;
using ProjectX.Infrastructure.Data.Models;

namespace ProjectX.Extensions
{
    public class SeedRoles
    {
        //Admin Role
        private const string AdminRoleName = "Admin";
        private const string AdminId = "9cb5e437-6f1c-45af-8748-37fab040c133";

        //SalonOwner Roles
        private const string SalonOwnerRoleName = "SalonOwner";
        private static readonly Dictionary<string, string> SalonOwnerIds = new Dictionary<string, string>
        {
            { "SalonOwnerSv", "7f6d9128-eb2a-4017-9be4-de846f4092a8" },
            { "SalonOwnerPl", "f8c71f1f-00d7-4f20-83d0-af5d2c6ab9e1" },
            { "SalonOwnerSf", "06af8218-64b2-4d25-ae5f-5b1dcb8ad498" },
            { "SalonOwnerVt", "f49b96c1-0e67-4e43-a68e-5cbecc1dd9b6" },
            { "SalonOwnerRs", "eb257b08-cc37-41c6-9bc4-7b85cf4dcb1e" },
            { "SalonOwnerVn", "bb5f0982-f2b5-4f59-bf4a-6ff7e5b86aa0" },
            { "SalonOwnerSz", "6d1741e7-037a-40fd-bd5a-914eb486a7f2" }
        };

        private const string UserRoleName = "User";
        private static readonly Dictionary<string, string> UserIds = new Dictionary<string, string>
        {
            { "User", "e0b4f60e-97d7-4d4c-bd9c-af9fdb80a12a" },
            { "User1", "70bfcd39-0281-4830-b825-1487b89274ee" }
        };

        public static IApplicationBuilder SeedAdministrator(IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdminRoleName))
                    {
                        return;
                    }

                    IdentityRole role = new IdentityRole(AdminRoleName);

                    await roleManager.CreateAsync(role);

                    User adminUser =
                        await userManager.FindByIdAsync(AdminId);

                    await userManager.AddToRoleAsync(adminUser, AdminRoleName);
                })
                .GetAwaiter()
                .GetResult();

            return app;
        }

        public static IApplicationBuilder SeedSalonOwners(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (var salonOwner in SalonOwnerIds)
            {
                Task.Run(async () =>
                {
                    var user = await userManager.FindByIdAsync(salonOwner.Value);
                    if (user != null && !await userManager.IsInRoleAsync(user, SalonOwnerRoleName))
                    {
                        if (!await roleManager.RoleExistsAsync(SalonOwnerRoleName))
                        {
                            var role = new IdentityRole(SalonOwnerRoleName);
                            await roleManager.CreateAsync(role);
                        }
                        await userManager.AddToRoleAsync(user, SalonOwnerRoleName);
                    }
                }).GetAwaiter().GetResult();
            }

            return app;
        }

        public static IApplicationBuilder SeedUsers(IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(UserRoleName))
                {
                    return;
                }

                IdentityRole role = new IdentityRole(UserRoleName);

                await roleManager.CreateAsync(role);

                foreach (var userId in UserIds)
                {
                    User user = await userManager.FindByIdAsync(userId.Value);
                    if (user != null && !await userManager.IsInRoleAsync(user, UserRoleName))
                    {
                        await userManager.AddToRoleAsync(user, UserRoleName);
                    }
                }
            }).GetAwaiter().GetResult();

            return app;
        }
    }
}
