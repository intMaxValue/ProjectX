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

            builder.HasData(new Salon[] { data.SalonSv, data.SalonSv1, data.SalonSv2, data.SalonSv3,
                data.SalonSf, data.SalonSf1, data.SalonSf2, data.SalonSf3,
                data.SalonPl, data.SalonPl1, data.SalonPl2,
                data.SalonVt, data.SalonVt1,
                data.SalonRs,
                data.SalonVn,
                data.SalonSz });
        }
    }
}