using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomer;
public sealed  record UpdateCustomerCommand  (string CompanyId,
         int Id,
         string Code,
        string Name,
        string GroupCode,
        int CustomerTypeId,
        string Address,
        string Address2,
        string CellPhone1,
        string CellPhone2,
        string Telephone,
         string Email,
         string TaxOffice,
         string TaxNumber,
         int SPECode1,
         int SPECode2,
         int SPECode3,
         int SPECode4,
         int SPECode5,
         string City,
         string Town,


         string UpdaterName

    ) : ICommand<UpdateCustomerCommandResponse>;




   