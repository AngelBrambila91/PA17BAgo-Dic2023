using Microsoft.EntityFrameworkCore;
namespace WorkingWithEFCore;

public class Northwind : DbContext
{
    public DbSet<Category>? Categories { get; set; }

    public DbSet<Customer>? Customers { get; set; }

    public DbSet<Employee>? Employees { get; set; }

    public DbSet<EmployeeTerritory>? EmployeeTerritories { get; set; }

    public DbSet<Order>? Orders { get; set; }

    public DbSet<OrderDetail>? OrderDetails { get; set; }

    public DbSet<Product>? Products { get; set; }

    public DbSet<Shipper>? Shippers { get; set; }

    public DbSet<Supplier>? Suppliers { get; set; }

    public DbSet<Territory>? Territories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
        string connection = $"Filename={path}";
        ConsoleColor backgroundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"Connection: {connection}");
        ForegroundColor = backgroundColor;
        optionsBuilder.UseSqlite(connection);
        //optionsBuilder.LogTo(WriteLine).EnableSensitiveDataLogging();

        // Using Lazy Loading
        optionsBuilder.UseLazyLoadingProxies();

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // FLUENT API
        // always use the model builder
        // Always define FIRST the ENTITY to Apply the Validations
        modelBuilder.Entity<Category>()
        .Property(category => category.CategoryName)
        .IsRequired()
        .HasMaxLength(15); // Then the property to validate

        // Fluent APi for cost on Product
        if(Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            modelBuilder.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();
        }

        // Global filter to remove discontinued products
        modelBuilder.Entity<Product>()
        .HasQueryFilter(p => !p.Discontinued);

        // Eager Loading : Load data early
        // Lazy Loading : Load data automatically just before its needed
        // Explicit Loading : Load data manually

    }

}