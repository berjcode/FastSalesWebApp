

using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.AuthFeatures.Queries.GetUserRolesByUserIdAndCompanyId;

public sealed record GetUserRolesByUserIdAndCompanyIdQuery(
    string UserId,
    string CompanyId

    ): IQuery<GetUserRolesByUserIdAndCompanyIdQueryResponse>;
