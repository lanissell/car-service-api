using CarService.Model;
using CarService.Model.CarModel;
using CarService.Model.HumanModel;
using CarService.Model.SparePartModel;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.CarSpace;

namespace DataAccessLayer;

public sealed class DataContext: DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarBrand> CarsModels { get; set; }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Client> Clients { get; set; }

    public DbSet<SparePart> SpareParts { get; set; }
    public DbSet<SparePartBrand> SparePartBrands { get; set; }
    public DbSet<SparePartType> SparePartTypes { get; set; }
    public DbSet<Favor> Favors { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarBrand>()
            .HasIndex(b => b.Name)
            .IsUnique();

        modelBuilder.Entity<SparePartBrand>()
            .HasIndex(s => s.Name)
            .IsUnique();

        modelBuilder.Entity<SparePartType>()
            .HasIndex(s => s.Name)
            .IsUnique();

        modelBuilder.Entity<Favor>()
            .HasIndex(f => f.Name)
            .IsUnique();

        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }
}