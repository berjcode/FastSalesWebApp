using Microsoft.EntityFrameworkCore;

namespace QuickSalesApp.Domain;

public interface IContextService
{
    DbContext CreateDbContextInstance(string companyId); 
}
