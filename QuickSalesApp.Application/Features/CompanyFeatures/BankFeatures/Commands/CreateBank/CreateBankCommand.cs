using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.CreateBank;

public sealed record CreateBankCommand(
   
    string Code,
    string Name,
     string BranchNumber,
     string BranchName,
      string Adress,
    string PhoneNumber,
    string CreatorName,

    string CompanyId

  ) : ICommand<CreateBankCommandResponse>;

