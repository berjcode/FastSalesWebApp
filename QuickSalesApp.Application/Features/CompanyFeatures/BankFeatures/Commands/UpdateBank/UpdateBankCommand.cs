using Microsoft.EntityFrameworkCore.Storage;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.UpdateBank;


public sealed record UpdateBankCommand(

    string CompanyId,
    int Id,
       string Name,
     string Code,
     string BranchNumber,
     string BranchName,
     string Adress,
     string PhoneNumber,
 
   
    string UpdaterName): ICommand<UpdateBankCommandResponse>;

