﻿
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.BankTransactionRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.BankTransactionRepositories;

public sealed  class BankTransactionCommandRepository :CompanyDbCommandRepository<BankTransaction>, IBankTransactionCommandRepository
{
}
