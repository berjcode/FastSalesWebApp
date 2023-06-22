namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllActiveVatType;

public sealed record GetAllActiveVatTypeQueryResponse(
        int Id,
        string Name,
        int Value
    );
