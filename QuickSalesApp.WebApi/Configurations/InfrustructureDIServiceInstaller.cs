using QuickSalesApp.Application.Abstractions;
using QuickSalesApp.Infrasturcture.Authentication;

namespace QuickSalesApp.WebApi.Configurations
{
    public class InfrustructureDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
        }
    }
}
