using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.CreateCustomerType;

public sealed class CreateCustomerTypeCommandHandler : ICommandHandler<CreateCustomerTypeCommand, CreateCustomerTypeCommandResponse>
{

    private readonly ICustomerTypeService _customerTypeService;

    public CreateCustomerTypeCommandHandler(ICustomerTypeService customerTypeService)
    {
        _customerTypeService = customerTypeService;
    }

    public async Task<CreateCustomerTypeCommandResponse> Handle(CreateCustomerTypeCommand request,
        CancellationToken cancellationToken)
    {
        CustomerType customerType= await _customerTypeService.GetByNameAsync(request.CompanyId, request.Name);
        if (customerType != null) throw new Exception("Bu Customer daha önce tanımlanmıştır");
     
        await _customerTypeService.CreateAsync(request, cancellationToken);
        return new();
    }
}
