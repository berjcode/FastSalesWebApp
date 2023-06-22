using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.RemoveVatType;

public sealed class RemoveVatTypeCommandHandler : ICommandHandler<RemoveVatTypeCommand, RemoveVatTypeCommandResponse>
{
    private readonly IVatTypeService _vatTypeService;

    public RemoveVatTypeCommandHandler(IVatTypeService vatTypeService)
    {
        _vatTypeService = vatTypeService;
    }

    public async Task<RemoveVatTypeCommandResponse> Handle(RemoveVatTypeCommand request, CancellationToken cancellationToken)
    {
        VatType vatType = await _vatTypeService.GetByIdAsync(request.id, request.CompanyId);
        if (vatType == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _vatTypeService.RemoveByIdHard(request);
        return new();
    }
}
