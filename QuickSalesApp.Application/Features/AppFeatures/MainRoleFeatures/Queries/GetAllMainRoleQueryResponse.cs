

using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Queries;

public sealed record GetAllMainRoleQueryResponse(IList<MainRole> MainRoles);

