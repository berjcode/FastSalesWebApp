using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.UpdateCustomerTransaction;

public sealed class UpdateCustomerTransactionCommandHandler : ICommandHandler<UpdateCustomerTransactionCommand, UpdateCustomerTransactionCommandResponse>
{
    private readonly ICustomerTransactionService _customerTransactionService;

    public UpdateCustomerTransactionCommandHandler(ICustomerTransactionService customerTransactionService)
    {
        _customerTransactionService = customerTransactionService;
    }

    public async Task<UpdateCustomerTransactionCommandResponse> Handle(UpdateCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        CustomerTransaction customerTransaction = await _customerTransactionService.GetByIdAsync(request.CompanyId, request.CustomerTransactionId);
        if (customerTransaction == null) throw new Exception("bu customerTransaction  bulunamadı");
     
        await _customerTransactionService.UpdateAsync(request);
        return new();
    }
}
