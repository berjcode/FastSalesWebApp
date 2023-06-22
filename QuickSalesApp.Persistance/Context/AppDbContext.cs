using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.AppEntities.Identity;

namespace QuickSalesApp.Persistance.Context;

public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<Company> Companies { get; set; }
    public DbSet<UserAndCompanyRelationship> UserAndCompanyRelationships { get; set; }
    public DbSet<MainRole> MainRoles { get; set; }
    public DbSet<MainRoleAndRoleRelationShip> MainAndRoleRelationShips { get; set; }
    public DbSet<MainRoleAndUserRelationship> MainRoleAndUserRelationships { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityUserRole<string>>();
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();

    }


    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {


        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("SqlServer");

            builder.UseSqlServer(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}
