namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetAllBankAccount;

public sealed record GetAllBankAccountQueryResponse(
    int Id,
    string Code,
    string Name,
    string IBAN,
    string AcountNumber,
    int CurrencyId,
    string CompanyId

    );