using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetVatType;

public sealed record GetVatTypeQuery(
        int Id,
        string CompanyId
    ) : IQuery<GetVatTypeQueryResponse>;
