using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.RemoveCustomerType;

public sealed class RemoveCustomerTypeCommandHandler : ICommandHandler<RemoveCustomerTypeCommand, RemoveCustomerTypeCommandResponse>
{
    private readonly ICustomerTypeService _customerTypeService;

    public RemoveCustomerTypeCommandHandler(ICustomerTypeService customerTypeService)
    {
        _customerTypeService = customerTypeService;
    }

    public async Task<RemoveCustomerTypeCommandResponse> Handle(RemoveCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        CustomerType checkEntity = await _customerTypeService.GetByIdAsync(request.CompanyId, request.id);
        if (checkEntity == null) throw new Exception("Bank Bulunamadı");
        await _customerTypeService.RemoveByIdHard(request.CompanyId, request.id);

        return new();
    }
}
