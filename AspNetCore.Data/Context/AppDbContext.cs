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
        public DbSet<AccountLogin> AccountLogins { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<AccountRoleType> AccountRoleTypes { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistDescription> ArtistDescriptions { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CatalogDescription> CatalogDescriptions { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogArtwork> CatalogArtworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasOne(p => p.Person)
                      .WithOne(p => p.Phone)
                      .HasForeignKey<Phone>(f => f.EntityID);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasOne(p => p.Person)
                      .WithOne(p => p.Email)
                      .HasForeignKey<Email>(f => f.EntityID);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasOne(p => p.Person)
                      .WithOne(p => p.Location)
                      .HasForeignKey<Location>(f => f.EntityID);
            });

            modelBuilder.Entity<AccountLogin>(entity =>
            {
                entity.HasOne(p => p.Person)
                      .WithOne(p => p.AccountLogin)
                      .HasForeignKey<AccountLogin>(f => f.EntityID);
            });

            modelBuilder.Entity<AccountRole>(entity =>
           {
               entity.HasOne(p => p.AccountLogin)
                     .WithOne(p => p.AccountRole)
                     .HasForeignKey<AccountRole>(f => f.EntityID);

               entity.HasOne(p => p.AccountRoleType)
                     .WithOne(p => p.AccountRole)
                     .HasForeignKey<AccountRole>(f => f.RoleTypeID);

               entity.HasOne(p => p.AccountRoleStatus)
                     .WithOne(p => p.AccountRole)
                     .HasForeignKey<AccountRole>(f => f.RoleStatusID);
           });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasOne(p => p.Person)
                      .WithMany(p => p.Artists)
                      .HasForeignKey(f => f.EntityID);
            });

            modelBuilder.Entity<ArtistDescription>(entity =>
            {
                entity.HasOne(p => p.Artist)
                      .WithOne(p => p.ArtistDescription)
                      .HasForeignKey<ArtistDescription>(f => f.ArtistID);
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.HasOne(p => p.Artist)
                      .WithMany(p => p.Catalogs)
                      .HasForeignKey(f => f.CatalogID);

                entity.HasOne(p => p.CatalogType)
                      .WithMany(p => p.Catalogs)
                      .HasForeignKey(f => f.CatalogTypeID);

                entity.HasOne(p => p.CatalogArtwork)
                      .WithOne(p => p.Catalog)
                      .HasForeignKey<Catalog>(f => f.CatalogID);

                entity.HasOne(p => p.CatalogDescription)
                      .WithOne(p => p.Catalog)
                      .HasForeignKey<Catalog>(f => f.CatalogID);
            });


        }
    }
}