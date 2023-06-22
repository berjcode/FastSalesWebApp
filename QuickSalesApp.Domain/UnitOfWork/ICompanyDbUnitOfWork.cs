using Microsoft.EntityFrameworkCore;
namespace QuickSalesApp.Domain.UnitOfWork
{
    public interface ICompanyDbUnitOfWork: IUnitOfWork
    {
        void SetDbContextInstance(DbContext context);

    }
}
