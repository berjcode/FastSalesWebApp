﻿using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.CustomerTransactionRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.CustomerTransactionRepositories;
public sealed class CustomerTransactionCommandRepository : CompanyDbCommandRepository<CustomerTransaction>, ICustomerTransactionCommandRepository
{
}
