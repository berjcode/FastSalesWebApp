using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.RemoveVatType;

public sealed record RemoveVatTypeCommand(
    int id,
    string CompanyId) : ICommand<RemoveVatTypeCommandResponse>;