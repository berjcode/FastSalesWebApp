

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetCustomer;

public sealed record GetCustomerQueryResponse(
          int Id,
          string Code,
          string Name,
          string GroupCode,
          string CustomerTypeName,
          string Address,
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
         bool? IsView,
         string CreatorName,
         DateTime? CreatedDate,
         string UpdaterName,
         DateTime? UpdateDate,
         bool? IsActive,
         string CompanyId,
         string City,
         string Town

    );
