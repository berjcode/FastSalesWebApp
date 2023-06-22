﻿using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.CategoryRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.CategoryRepositories;
public sealed class CategoryCommandRepository :CompanyDbCommandRepository<Category>, ICategoryCommandRepository
{
}
