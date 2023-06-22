using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.RemoveCustomerTransaction;

public sealed class RemoveCustomerTransactionCommandHandler : ICommandHandler<RemoveCustomerTransactionCommand, RemoveCustomerTransactionCommandResponse>
{

    private readonly ICustomerTransactionService _customerTransactionService;

    public RemoveCustomerTransactionCommandHandler(ICustomerTransactionService customerTransactionService)
    {
        _customerTransactionService = customerTransactionService;
    }
    public async Task<RemoveCustomerTransactionCommandResponse> Handle(RemoveCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        CustomerTransaction checkEntity = await _customerTransactionService.GetByIdAsync(request.CompanyId, request.CustomerTransactionId);
        if (checkEntity == null) throw new Exception("CustomerTransaction Bulunamadı");
        await _customerTransactionService.RemoveByIdHard(request.CompanyId, request.CustomerTransactionId);

        return new();
    }
}
