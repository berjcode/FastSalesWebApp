using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.UpdateSafe;

public sealed class UpdateSafeCommandHandler : ICommandHandler<UpdateSafeCommand, UpdateSafeCommandResponse>
{
    private readonly ISafeService _service;

    public UpdateSafeCommandHandler(ISafeService service)
    {
        _service = service;
    }

    public async Task<UpdateSafeCommandResponse> Handle(UpdateSafeCommand request, CancellationToken cancellationToken)
    {
        Safe safe = await _service.GetByIdAsync(request.Id, request.CompanyId);
        if (safe == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        Safe safe2 = await _service.GetByNameAsync(request.Name, request.CompanyId);
        if (safe2 != null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        await _service.UpdateAsync(request);
        return new();
    }
}
