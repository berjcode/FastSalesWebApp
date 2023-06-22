using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.CreateSafe;

public sealed record CreateSafeCommand(
        string Code,
        string Name,
        int CurrencyType,
        decimal Credit,
        decimal Debt,
        decimal Remainder,
        string CreatorName,
        string CompanyId
    ) : ICommand<CreateSafeCommandResponse>;
