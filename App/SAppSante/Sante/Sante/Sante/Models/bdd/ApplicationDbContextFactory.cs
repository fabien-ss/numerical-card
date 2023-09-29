namespace S5_RH.Models.bdd;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public static class ApplicationDbContextFactory
{
    public static ApplicationDbContext Create()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new ApplicationDbContext(options);
    }
}