using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.RemoveSoftProductTransaction;

public sealed record RemoveSoftProductTransactionCommand(
        int id,
        string CompanyId,
        bool IsDelete,
        string DeleterName
    ) : ICommand<RemoveSoftProductTransactionCommandResponse>;