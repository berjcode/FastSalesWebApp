using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.StateSafe;

public sealed class StateSafeCommandHandler : ICommandHandler<StateSafeCommand, StateSafeCommandResponse>
{
    private readonly ISafeService _service;

    public StateSafeCommandHandler(ISafeService service)
    {
        _service = service;
    }

    public async Task<StateSafeCommandResponse> Handle(StateSafeCommand request, CancellationToken cancellationToken)
    {
        Safe safe = await _service.GetByIdAsync(request.Id, request.CompanyId);
        if (safe == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        safe.IsActive = request.IsActive;
        safe.DeleterName = request.DeleterName;
        safe.DeletedTime = DateTime.Now;

        await _service.ChangeState(safe, request.CompanyId);
        return new();
    }
}
