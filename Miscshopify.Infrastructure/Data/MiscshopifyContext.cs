using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Seed;
using Newtonsoft.Json;

namespace Miscshopify.Infrastructure.Data;

public class MiscshopifyContext : IdentityDbContext<ApplicationUser>
{
    public MiscshopifyContext(DbContextOptions<MiscshopifyContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        string path = Directory.GetCurrentDirectory();
        builder.ApplyConfiguration(new InitialDataSeed<Category>(path + ".Infrastructure\\SeedData\\categories.json"));
        builder.ApplyConfiguration(new InitialDataSeed<Product>(path + ".Infrastructure\\SeedData\\products.json"));

        base.OnModelCreating(builder);

        SeedUsersRoles seedUsersRoles = new();
        builder.Entity<IdentityRole>().HasData(seedUsersRoles.Roles);
        builder.Entity<ApplicationUser>().HasData(seedUsersRoles.Users);
        builder.Entity<IdentityUserRole<string>>().HasData(seedUsersRoles.UserRoles);

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public virtual DbSet<SiteSettings> SiteSettings { get; set; }


    public List<T> SeedUserData<T>(string filePath) where T : class
    {
        var model = new List<T>();
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            model = JsonConvert.DeserializeObject<List<T>>(json);
        }
        return model;
    }
}