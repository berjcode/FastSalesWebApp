using FluentValidation;
using MediatR;
using QuickSalesApp.Application;
using QuickSalesApp.Application.Behavior;

namespace QuickSalesApp.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(AssemblyReference)));

            services.AddTransient(typeof(IPipelineBehavior<,>),(
                typeof(ValidationBehavior<,>)));

            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
        }
    }
}
