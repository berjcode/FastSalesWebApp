using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Queries.GetAllMainRoleRL;

public sealed record GetAllMainRoleAndRoleRLQueryResponse(
    List<MainRoleAndRoleRelationShip> mainRoleAndRoleRelationShips
    );

