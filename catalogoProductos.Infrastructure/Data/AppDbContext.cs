using catalogoProductos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace catalogoProductos.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Client>().ToTable("clients");
        modelBuilder.Entity<Seller>().ToTable("sellers");
        modelBuilder.Entity<Admin>().ToTable("admins");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasIndex(c => c.DocNumber)
                .IsUnique();

            entity.HasIndex(c => c.Email)
                .IsUnique();

            entity.HasIndex(c => c.UserName)
                .IsUnique();
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasIndex(s => s.DocNumber)
                .IsUnique();

            entity.HasIndex(s => s.Email)
                .IsUnique();

            entity.HasIndex(s => s.UserName)
                .IsUnique();
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasIndex(a => a.Id)
                .IsUnique();
            
            entity.HasIndex(a => a.Email)
                .IsUnique();
        });
            
        
        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Product> Products { get; set; }
    public DbSet<Sales> Sales { get; set; }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Admin> Admins { get; set; }
}