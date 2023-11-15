using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace Common.Entities;

public static class NorthwindContextExtensions
{
    
    public static IServiceCollection AddNorthwindContext(this IServiceCollection services, string relativePath = "..")
    {
        string databasePath = Path.Combine(relativePath, "Northwind.db");

        services.AddDbContext<NorthwindContext> (options =>
        {
            options.UseSqlite($"Data Source={databasePath}");
            // Shyntetic Sugar
            options.LogTo(Console.WriteLine, new[] {
                Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting
            });
        });
        return services;
    }

} 
