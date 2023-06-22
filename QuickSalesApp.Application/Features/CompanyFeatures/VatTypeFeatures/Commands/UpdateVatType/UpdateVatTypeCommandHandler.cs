using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.UpdateVatType;

public sealed class UpdateVatTypeCommandHandler : ICommandHandler<UpdateVatTypeCommand, UpdateVatTypeCommandResponse>
{
    private readonly IVatTypeService _vatTypeService;

    public UpdateVatTypeCommandHandler(IVatTypeService vatTypeService)
    {
        _vatTypeService = vatTypeService;
    }

    public async Task<UpdateVatTypeCommandResponse> Handle(UpdateVatTypeCommand request, CancellationToken cancellationToken)
    {
        VatType vatType = await _vatTypeService.GetByIdAsync(request.Id, request.CompanyId);
        if (vatType == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        VatType vatType2 = await _vatTypeService.GetByNameAsync(request.Name, request.CompanyId);
        if (vatType2 != null && vatType2.IsActive == true && vatType2.Id != request.Id && vatType2.Name == request.Name) throw new Exception("Değiştirmek İstediğiniz KDV Adı Zaten Kullanımda");

        await _vatTypeService.UpdateAsync(request);
        return new();
    }
}
