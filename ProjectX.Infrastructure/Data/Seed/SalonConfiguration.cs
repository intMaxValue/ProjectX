using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Infrastructure.Data.Models;

namespace ProjectX.Infrastructure.Data.Seed
{
    internal class SalonConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            var data = new SeedData();

            builder.HasData(new Salon[] { data.SalonSv, data.SalonPl, data.SalonRs, data.SalonVt, data.SalonSf, data.SalonVn, data.SalonSz });
        }
    }
}