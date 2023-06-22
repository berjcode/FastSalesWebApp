using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Domain.AppEntities.Identity;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.WebApi.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(SectionName)));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();



            services.AddAutoMapper(typeof(QuickSalesApp.Persistance.AssemblyReference).Assembly);
        }
    }
}
