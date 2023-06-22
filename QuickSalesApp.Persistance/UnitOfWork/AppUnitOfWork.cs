using QuickSalesApp.Domain;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.UnitOfWork;

public sealed class AppUnitOfWork : IAppUnitOfWork
{

    private AppDbContext _context;

    public AppUnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int count = await _context.SaveChangesAsync(cancellationToken);
        return count;
    }
}
