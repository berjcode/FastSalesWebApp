using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.CreateSafeTransaction;

public sealed class CreateSafeTransactionCommandHandler : ICommandHandler<CreateSafeTransactionCommand, CreateSafeTransactionCommandResponse>
{
    private readonly ISafeTransactionService _service;

    public CreateSafeTransactionCommandHandler(ISafeTransactionService service)
    {
        _service = service;
    }

    public async Task<CreateSafeTransactionCommandResponse> Handle(CreateSafeTransactionCommand request, CancellationToken cancellationToken)
    {
        await _service.CreateAsync(request, cancellationToken);
        return new();
    }
}
