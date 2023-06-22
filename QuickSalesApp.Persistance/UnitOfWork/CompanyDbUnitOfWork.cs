using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;


namespace QuickSalesApp.Persistance.UnitOfWork;

public sealed class CompanyDbUnitOfWork : ICompanyDbUnitOfWork
{
    private CompanyDbContext _context;

    public void SetDbContextInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
       int count = await _context.SaveChangesAsync(cancellationToken);
        return count;
    }
}
