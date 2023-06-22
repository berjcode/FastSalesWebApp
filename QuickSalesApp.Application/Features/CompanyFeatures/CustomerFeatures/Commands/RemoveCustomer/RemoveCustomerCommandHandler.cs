using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.RemoveCustomer;

public sealed class RemoveCustomerCommandHandler : ICommandHandler<RemoveCustomerCommand, RemoveCustomerCommandResponse>
{
    private readonly ICustomerService _customerService;

    public RemoveCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public  async Task<RemoveCustomerCommandResponse> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = await _customerService.GetByIdAsync(request.CompanyId, request.Id);
        if (customer == null) throw new Exception("Silmek istdiğiniz Customer bulunamadı");

        await _customerService.RemoveByIdHard(request.CompanyId, request.Id);
        return new();
    }
}
