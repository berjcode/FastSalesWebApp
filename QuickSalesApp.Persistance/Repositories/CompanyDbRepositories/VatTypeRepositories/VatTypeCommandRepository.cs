using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.VatTypeRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.VatTypeRepositories
{
    public sealed class VatTypeCommandRepository
        : CompanyDbCommandRepository<VatType>, IVatTypeCommandRepository
    {
    }
}
