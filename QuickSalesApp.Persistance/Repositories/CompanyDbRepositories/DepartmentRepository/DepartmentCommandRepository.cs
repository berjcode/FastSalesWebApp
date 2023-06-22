﻿using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.DepartmentRepositories;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.DepartmentRepository;

public sealed class DepartmentCommandRepository : CompanyDbCommandRepository<Department> ,IDepartmentCommandRepository
{
}
