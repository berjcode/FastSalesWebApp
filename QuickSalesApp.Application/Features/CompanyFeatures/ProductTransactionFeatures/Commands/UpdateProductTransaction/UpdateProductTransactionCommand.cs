using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.UpdateProductTransaction;

public sealed record UpdateProductTransactionCommand(
        int Id,
        string PlugNo,
        string ProductCode,
        string Text,
        decimal EnteringQuantity,
        decimal OutgoingQuantity,
        decimal Remainder,
        int ProcessTypeId,
        string UpdaterName,
        string CompanyId
    ) : ICommand<UpdateProductTransactionCommandResponse>;