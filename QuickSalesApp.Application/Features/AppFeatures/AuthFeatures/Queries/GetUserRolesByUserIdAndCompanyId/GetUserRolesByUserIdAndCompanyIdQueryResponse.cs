

namespace QuickSalesApp.Application.Features.AppFeatures.AuthFeatures
    .Queries.GetUserRolesByUserIdAndCompanyId;

public sealed record GetUserRolesByUserIdAndCompanyIdQueryResponse(
    IList<string> Roles);


