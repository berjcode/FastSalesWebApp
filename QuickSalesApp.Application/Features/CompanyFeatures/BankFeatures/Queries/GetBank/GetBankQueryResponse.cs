

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetBank;

public sealed record GetBankQueryResponse(
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
