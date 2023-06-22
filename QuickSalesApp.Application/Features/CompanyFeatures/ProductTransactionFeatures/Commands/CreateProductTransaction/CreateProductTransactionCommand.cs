using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.CreateProductTransaction;

public sealed record CreateProductTransactionCommand(
        string PlugNo,
        string ProductCode,
        string Text,
        decimal EnteringQuantity,
        decimal OutgoingQuantity,
        decimal Remainder,
        int ProcessTypeId,
        string CreatorName,
        string CompanyId
    ) : ICommand<CreateProductTransactionCommandResponse>;
