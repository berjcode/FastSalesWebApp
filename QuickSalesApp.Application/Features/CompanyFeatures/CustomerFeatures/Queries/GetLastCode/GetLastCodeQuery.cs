using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetLastCode;

public sealed record GetLastCodeQuery(
        string CompanyId
    ): IQuery<GetLastCodeQueryResponse>;
