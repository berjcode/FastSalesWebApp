using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;

public sealed record GetAllCustomerQueryResponse (int Id,
  
         string Code,
        string Name,
        string GroupCode,
         int CustomerTypeId,
        string CustomerType,
        string CellPhone1,
        string CellPhone2,
         string Telephone,
         string Email,
         string TaxOffice,
         string TaxNumber,
         string Address,
          string Address2,
         int SPECode1,
         int SPECode2,
         int SPECode3,
         int SPECode4,
         int SPECode5,   
         bool? IsActive,
         string CompanyId,
          string CreatorName,
         DateTime? CreatedDate,
         string UpdaterName,
         DateTime? UpdateDate,
         string City,
         string Town
    );

