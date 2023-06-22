using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.CreateVatType;

public sealed class CreateVatTypeCommandHandler : ICommandHandler<CreateVatTypeCommand, CreateVatTypeCommandResponse>
{
    private readonly IVatTypeService _vatTypeService;

    public CreateVatTypeCommandHandler(IVatTypeService vatTypeService)
    {
        _vatTypeService = vatTypeService;
    }

    public async Task<CreateVatTypeCommandResponse> Handle(CreateVatTypeCommand request, CancellationToken cancellationToken)
    {
        VatType vatType = await _vatTypeService.GetByNameAsync(request.Name, request.CompanyId);
        if (vatType != null) throw new Exception("Bu KDV Türü Zaten Ekli");

        await _vatTypeService.CreateAsync(request,cancellationToken);
        return new();
    }
}
