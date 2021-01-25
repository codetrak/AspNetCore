using AspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Location> Locations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasOne(p => p.Person)
                .WithOne(p => p.Phone)
                .HasForeignKey<Person>(f => f.EntityID);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasOne(p => p.Person)
                .WithOne(e => e.Email)
                .HasForeignKey<Person>(f => f.EntityID);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasOne(p => p.Person)
                .WithOne(l => l.Location)
                .HasForeignKey<Person>(f => f.EntityID);
            });

        }
    }
}