using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QuickSalesApp.Domain.Abstractions;
using QuickSalesApp.Domain.AppEntities;


namespace QuickSalesApp.Persistance.Context
{
    public sealed class CompanyDbContext:DbContext
    {

        private string ConnectionString= "";
      

        public CompanyDbContext( Company company=null)
        {
         
           if(company != null)
            {
                if (company.ServerUserId == "")
                    ConnectionString = $"server={company.ServerName};" +
                       $"Initial Catalog={company.DatabaseName};Integrated Security=True" +
                       $";Connect Timeout=30;Encrypt=False;" +
                       $"TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                else
                    ConnectionString = $"server={company.ServerName};" +
                        $"Initial Catalog={company.DatabaseName};" +
                        $"User Id={company.ServerUserId};Password={company.ServerPassword};Integrated Security=True" +
                       $";Connect Timeout=30;Encrypt=False;" +
                       $"TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            }


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);



        public class CompanydbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            private readonly AppDbContext dbContext;

           

            public CompanyDbContext CreateDbContext(string[] args)
            {
              
                return new CompanyDbContext();
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(p => p.CreatedDate)
                        .CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdateDate)
                        .CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
