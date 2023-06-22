﻿using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.BankAccountRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.BankAccountRepositories;

public sealed class BankAccountQueryRepository: CompanyDbQueryRepository<BankAccount>, IBankAccountQueryRepository
{
}
