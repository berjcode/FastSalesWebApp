namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetBankAccount;

public sealed record GetBankAccountQueryResponse(
    int Id,
    string Code,
    string Name,
    string IBAN,
    string AcountNumber,
    int CurrencyId,
    string CompanyId,
     string CreatorName,
     DateTime? CreatedDate,
     string UpdaterName,
     DateTime? UpdateDate,
     bool? IsActive
    );