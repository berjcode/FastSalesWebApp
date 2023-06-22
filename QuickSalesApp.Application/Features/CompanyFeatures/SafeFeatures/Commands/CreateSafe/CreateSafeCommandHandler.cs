using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.CreateSafe;

public sealed class CreateSafeCommandHandler : ICommandHandler<CreateSafeCommand, CreateSafeCommandResponse>
{

    private readonly ISafeService _service;

    public CreateSafeCommandHandler(ISafeService service)
    {
        _service = service;
    }

    public async Task<CreateSafeCommandResponse> Handle(CreateSafeCommand request, CancellationToken cancellationToken)
    {
        Safe safe = await _service.GetByNameAsync(request.Name, request.CompanyId);
        if (safe != null) throw new Exception("Eklemek Istediğiniz Kasa Zaten Ekli.");

        await _service.CreateAsync(request, cancellationToken);
        return new();
    }
}
