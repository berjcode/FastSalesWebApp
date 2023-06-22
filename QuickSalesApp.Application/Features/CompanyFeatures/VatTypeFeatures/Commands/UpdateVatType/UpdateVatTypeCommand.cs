using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.UpdateVatType;

public sealed record UpdateVatTypeCommand(
        int Id,
        string Name,
        int Value,
        string UpdaterName,
        string CompanyId
    ) : ICommand<UpdateVatTypeCommandResponse>;