using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllGroupCodes;

public sealed record GetAllGroupCodesQuery(
        string CompanyId
    ) : IQuery<GetAllGroupCodesQueryResponse>;