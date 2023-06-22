using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.UpdateSafe;

public sealed record UpdateSafeCommand(
        int Id,
        string Code,
        string Name,
        int CurrencyType,
        decimal Credit,
        decimal Debt,
        decimal Remainder,
        string UpdaterName,
        string CompanyId
    ) : ICommand<UpdateSafeCommandResponse>;