using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.CreateCustomerTransaction;

public sealed class CreateCustomerTransactionCommandHandler : ICommandHandler<CreateCustomerTransactionCommand, CreateCustomerTransactionCommandResponse>
{
    private readonly ICustomerTransactionService _customerTransactionService;

    public CreateCustomerTransactionCommandHandler(ICustomerTransactionService customerTransactionService)
    {
        _customerTransactionService = customerTransactionService;
    }

    public async Task<CreateCustomerTransactionCommandResponse> Handle(CreateCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        //CustomerTransaction customerTransaction = await _customerTransactionService.GetByCodeAsync(request.CompanyId,request.CustomerCode);
        //if (customerTransaction != null) throw new Exception("bu customerTransaction Daha önce tanımlanmıştır");

        await _customerTransactionService.CreateAsync(request, cancellationToken);

        return new();
    }
}

