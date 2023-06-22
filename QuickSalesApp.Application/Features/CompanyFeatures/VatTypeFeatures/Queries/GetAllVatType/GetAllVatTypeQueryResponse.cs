namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllVatType;

public sealed record GetAllVatTypeQueryResponse(
        int Id,
        string Name,
        int Value,
        string CreatorName,
        string CreatedDate,
        string UpdateDate,
        string UpdaterName,
        bool IsActive
    );