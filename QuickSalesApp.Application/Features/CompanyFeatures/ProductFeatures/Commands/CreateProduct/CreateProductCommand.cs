using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;

public sealed record CreateProductCommand(
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
    string CreatorName,
    int Factor,
    bool IsDefault,
    int UnitId,
    bool IsVat,
    decimal Price,
    string Barcode
    ) : ICommand<CreateProductCommandResponse>;
