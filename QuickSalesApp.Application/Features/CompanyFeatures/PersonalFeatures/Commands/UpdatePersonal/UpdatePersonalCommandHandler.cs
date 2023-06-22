using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.UpdatePersonal;

public sealed class UpdatePersonalCommandHandler : ICommandHandler<UpdatePersonalCommand, UpdatePersonalCommandResponse>
{
    private readonly IPersonalService _personalService;

    public UpdatePersonalCommandHandler(IPersonalService personalService)
    {
        _personalService = personalService;
    }

    public async Task<UpdatePersonalCommandResponse> Handle(UpdatePersonalCommand request, CancellationToken cancellationToken)
    {
        Personal personal = await _personalService.GetByIdAsync(request.Id, request.CompanyId);
        if (personal == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        personal.UpdateDate = DateTime.Now;
        personal.UpdaterName = request.UpdaterName;

        await _personalService.UpdateAsync(request);
        return new();
    }
}
