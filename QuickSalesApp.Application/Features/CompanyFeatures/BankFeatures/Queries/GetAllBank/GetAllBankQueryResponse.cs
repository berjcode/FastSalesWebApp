using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetAllBank;

public sealed record GetAllBankQueryResponse(
    int Id,
  string Name,
  string BranchNumber,
  string BranchName,
  string Adress,
  string PhoneNumber,
  string CreatorName,
  DateTime? CreatedDate,
  string UpdaterName,
  DateTime? UpdateDate,
  bool? IsActive,
  string CompanyId
 );





