﻿using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.ProductUnitRepositories
{
    public interface IProductUnitCommandRepository
        : ICompanyDbCommandRepository<ProductUnit>
    {
    }
}
