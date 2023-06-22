using QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using QuickSalesApp.Domain.AppEntities;


namespace QuickSalesApp.Application.Services.AppServices
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken);
        Task MigrateCompanyDatabases();
        Task<Company?> GetCompanyByName(string name, CancellationToken cancellationToken);
        IQueryable<Company> GetAll();

    }
}
