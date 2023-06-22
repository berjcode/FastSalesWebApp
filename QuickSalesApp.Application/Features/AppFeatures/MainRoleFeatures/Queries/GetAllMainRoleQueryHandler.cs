

using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Queries;

public sealed class GetAllMainRoleQueryHandler : IQueryHandler<GetAllMainRoleQuery, GetAllMainRoleQueryResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public GetAllMainRoleQueryHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async  Task<GetAllMainRoleQueryResponse> Handle(GetAllMainRoleQuery request, CancellationToken cancellationToken)
    {
        var result = _mainRoleService.GetAll();

        return new(await result.ToListAsync());
    }
}

