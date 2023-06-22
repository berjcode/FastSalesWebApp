using System.Windows.Input;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.RemoveCustomerTransaction;

public sealed record RemoveCustomerTransactionCommandResponse(
   string Message ="Başarıyla silindi."
    );
