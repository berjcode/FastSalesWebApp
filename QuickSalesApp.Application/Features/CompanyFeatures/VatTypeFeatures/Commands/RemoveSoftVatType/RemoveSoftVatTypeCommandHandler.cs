using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.RemoveSoftVatType;

public sealed class RemoveSoftVatTypeCommandHandler : ICommandHandler<RemoveSoftVatTypeCommand, RemoveSoftVatTypeCommandResponse>
{
    private readonly IVatTypeService _vatTypeService;

    public RemoveSoftVatTypeCommandHandler(IVatTypeService vatTypeService)
    {
        _vatTypeService = vatTypeService;
    }

    public async Task<RemoveSoftVatTypeCommandResponse> Handle(RemoveSoftVatTypeCommand request, CancellationToken cancellationToken)
    {
        VatType vatType = await _vatTypeService.GetByIdAsync(request.id, request.CompanyId);
        if (vatType == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        var check = await _vatTypeService.GetByIdForCheck(request.CompanyId, request.id);
        if (check.ProductName != null) throw new Exception(ExceptionMessage.VatTypeNotDeleteException);

        vatType.IsDelete = request.IsDelete;
        vatType.DeleterName = request.DeleterName;
        vatType.DeletedTime = DateTime.Now;
        vatType.IsActive = false;

        await _vatTypeService.RemoveByIdSoft(request.CompanyId, vatType);
        return new();
    }
}
