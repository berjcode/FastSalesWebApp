using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
        int Id,
        string Code,
        string Name,
        string Photo,
        int CategoryId,
        int ProductTypeId,
        int VatTypeId,
        string GroupCode,
        int SPECode1,
        int SPECode2,
        int SPECode3,
        int SPECode4,
        int SPECode5,
        string CompanyId,
        string UpdaterName
    ) : ICommand<UpdateProductCommandResponse>;
