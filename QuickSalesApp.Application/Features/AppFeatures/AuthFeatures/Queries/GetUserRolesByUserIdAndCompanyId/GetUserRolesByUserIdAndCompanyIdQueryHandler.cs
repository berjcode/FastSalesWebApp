

using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using System.Runtime.CompilerServices;

namespace QuickSalesApp.Application.Features.AppFeatures.AuthFeatures.Queries
    .GetUserRolesByUserIdAndCompanyId;

public sealed class GetUserRolesByUserIdAndCompanyIdQueryHandler : IQueryHandler<GetUserRolesByUserIdAndCompanyIdQuery, GetUserRolesByUserIdAndCompanyIdQueryResponse>
{
    private readonly IAuthService _authService;

    public GetUserRolesByUserIdAndCompanyIdQueryHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<GetUserRolesByUserIdAndCompanyIdQueryResponse> Handle(GetUserRolesByUserIdAndCompanyIdQuery request, CancellationToken cancellationToken)
    {
        IList<string> roles = await _authService.GetRolesByUserIdAndCompanyId(request.UserId, request.CompanyId);

        return new(roles);
    }
}
