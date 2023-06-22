namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllFilterVatType;

public sealed record GetAllFilterVatTypeQueryResponse(
        int Id,
        string Name,
        int Value,
        string CreatorName,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate,
        bool? IsActive
    );
