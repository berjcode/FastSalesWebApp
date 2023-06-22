using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.RemoveSafe;

public sealed class RemoveSafeCommandHandler : ICommandHandler<RemoveSafeCommand, RemoveSafeCommandResponse>
{
    private readonly ISafeService _service;

    public RemoveSafeCommandHandler(ISafeService service)
    {
        _service = service;
    }

    public async Task<RemoveSafeCommandResponse> Handle(RemoveSafeCommand request, CancellationToken cancellationToken)
    {
        Safe safe = await _service.GetByIdAsync(request.id, request.CompanyId);
        if (safe == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _service.RemoveByIdHard(request);
        return new();
    }
}
