namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetVatType;

public sealed record GetVatTypeQueryResponse(
        int Id,
        string Name,
        int Value,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate,
        bool? IsActive
    );