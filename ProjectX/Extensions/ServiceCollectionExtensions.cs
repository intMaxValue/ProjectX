using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.Core.Services;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;

namespace ProjectX.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string clientId)
        {
            services.AddSingleton<RssFeedService>();
            services.AddScoped<ISalonService, SalonService>();
            services.AddScoped<IUserProfileService, UserProfileService>();

            services.AddSignalR();
            services.AddScoped<IChatService, ChatService>();

            services.AddHttpClient<ImageUploader>();

            // Register ImageUploader with clientId
            services.AddTransient<ImageUploader>(provider =>
                new ImageUploader(provider.GetRequiredService<HttpClient>(), clientId));

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login"; // Setting the correct login path
            });

            
            services.AddDatabaseDeveloperPageExceptionFilter();

            using var serviceProvider = services.BuildServiceProvider();
            SeedRoles(serviceProvider).Wait();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddRazorPages();
            return services;
        }

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Define roles
            string[] roleNames = { "Admin", "User", "SalonOwner" };

            foreach (var roleName in roleNames)
            {
                // Check if the role doesn't exist
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    // Create the role
                    var role = new IdentityRole(roleName);
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
