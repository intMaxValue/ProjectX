using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.Infrastructure.Data.Models.Chat;
using ProjectX.Infrastructure.Data.Seed;

namespace ProjectX.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Salon> Salons { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Photo> Photos { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<ChatRoom> ChatRooms { get; set; } = null!;
        public DbSet<ChatMessage> ChatMessages { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SalonConfiguration());


            base.OnModelCreating(modelBuilder);

            // Fluent API configurations
            modelBuilder.Entity<ChatMessage>()
                .HasOne(cm => cm.ChatRoom)
                .WithMany(cr => cr.Messages)
                .HasForeignKey(cm => cm.ChatRoomId);
            
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Salon)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.SalonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Photos)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Salon>()
                .HasMany(s => s.Photos)
                .WithOne(p => p.Salon)
                .HasForeignKey(p => p.SalonId);

            modelBuilder.Entity<Salon>()
                .HasMany(s => s.Reviews)
                .WithOne(r => r.Salon)
                .HasForeignKey(r => r.SalonId);

            modelBuilder.Entity<Salon>()
                .HasMany(s => s.Appointments)
                .WithOne(a => a.Salon)
                .HasForeignKey(a => a.SalonId);

            modelBuilder.Entity<Photo>()
                .HasOne(p => p.User)
                .WithMany(u => u.Photos)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Salon)
                .WithMany(s => s.Photos)
                .HasForeignKey(p => p.SalonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Salon)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.SalonId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
