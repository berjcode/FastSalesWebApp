
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Queries.GetAllMainRoleRL;

public sealed class GetAllMainRoleAndRoleRLQueryHandler : IQueryHandler<GetAllMainRoleAndRoleRLQuery, GetAllMainRoleAndRoleRLQueryResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _roleRelationshipService;

    public GetAllMainRoleAndRoleRLQueryHandler(IMainRoleAndRoleRelationshipService roleRelationshipService)
    {
        _roleRelationshipService = roleRelationshipService;
    }

    public async Task<GetAllMainRoleAndRoleRLQueryResponse> Handle(GetAllMainRoleAndRoleRLQuery request, CancellationToken cancellationToken)
    {
        return new(await _roleRelationshipService.GetAll().Include("AppRole")
            .Include("MainRole")
            .ToListAsync());
    }
}
