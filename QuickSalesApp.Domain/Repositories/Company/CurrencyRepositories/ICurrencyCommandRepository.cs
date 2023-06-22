﻿using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.CurrencyRepositories;

public interface ICurrencyCommandRepository : ICompanyDbCommandRepository<Currency>
{
}
