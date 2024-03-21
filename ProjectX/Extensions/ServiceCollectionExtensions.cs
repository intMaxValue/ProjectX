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
            services.AddHttpClient<ImageUploader>();

            // Register ImageUploader with clientId
            services.AddTransient<ImageUploader>(provider =>
                new ImageUploader(provider.GetRequiredService<HttpClient>(), clientId));

            services.AddDatabaseDeveloperPageExceptionFilter();

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
    }
}
