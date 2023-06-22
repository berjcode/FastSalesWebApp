using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Persistance.Context;



namespace QuickSalesApp.Persistance;

public sealed class ContextService : IContextService
{

    private readonly AppDbContext _appContext;

    public ContextService(AppDbContext appContext)
    {
        _appContext = appContext;
    }

    public DbContext CreateDbContextInstance(string companyId)
    {
       Company company = _appContext.Set<Company>().Find( companyId);
        return new CompanyDbContext(company);
    }

   
}
