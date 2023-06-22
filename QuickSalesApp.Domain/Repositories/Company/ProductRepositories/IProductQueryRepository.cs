using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSalesApp.Domain.Repositories.Company.ProductRepositories
{
    public interface IProductQueryRepository : ICompanyDbQueryRepository<Product>
    {
    }
}
