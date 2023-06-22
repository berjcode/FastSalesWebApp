using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.RemoveSoftPersonal;

public sealed class RemoveSoftPersonalCommandHandler : ICommandHandler<RemoveSoftPersonalCommand, RemoveSoftPersonalCommandResponse>
{
    private readonly IPersonalService _personalService;

    public RemoveSoftPersonalCommandHandler(IPersonalService personalService)
    {
        _personalService = personalService;
    }

    public async Task<RemoveSoftPersonalCommandResponse> Handle(RemoveSoftPersonalCommand request, CancellationToken cancellationToken)
    {
        Personal personal = await _personalService.GetByIdAsync(request.Id,request.CompanyId);
        if (personal == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _personalService.RemoveByIdSoft(request.CompanyId, request.Id);
        return new();
    }
}
