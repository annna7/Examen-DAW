using Microsoft.EntityFrameworkCore;
using test_examen.Models;

namespace test_examen;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.BankAccount)
            .WithOne(b => b.User)
            .HasForeignKey<BankAccount>(b => b.UserId);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.FavoriteProducts)
            .WithMany(p => p.SavedByUsers)
            .UsingEntity(j => j.ToTable("SavedProducts"));
    }
}