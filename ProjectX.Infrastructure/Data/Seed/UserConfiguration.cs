using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Infrastructure.Data.Models;

namespace ProjectX.Infrastructure.Data.Seed
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var data = new SeedData();

            builder.HasData(new User[] { data.Admin, data.User,
                data.SalonOwnerSv, data.SalonOwnerPl, data.SalonOwnerRs, data.SalonOwnerVt, data.SalonOwnerSf, data.SalonOwnerSz, data.SalonOwnerVn });
        }
    }
}