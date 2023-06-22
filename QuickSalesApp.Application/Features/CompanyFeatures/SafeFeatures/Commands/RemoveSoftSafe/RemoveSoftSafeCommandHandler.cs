using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.RemoveSoftSafe;

public sealed class RemoveSoftSafeCommandHandler : ICommandHandler<RemoveSoftSafeCommand, RemoveSoftSafeCommandResponse>
{
    private readonly ISafeService _service;

    public RemoveSoftSafeCommandHandler(ISafeService service)
    {
        _service = service;
    }

    public async Task<RemoveSoftSafeCommandResponse> Handle(RemoveSoftSafeCommand request, CancellationToken cancellationToken)
    {
        Safe safe = await _service.GetByIdAsync(request.id, request.CompanyId);
        if (safe == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _service.RemoveByIdSoft(request.CompanyId,request.id);
        return new();
    }
}
