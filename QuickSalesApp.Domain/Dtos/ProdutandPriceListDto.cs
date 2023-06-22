using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Domain.Dtos;

public sealed  record ProdutandPriceListDto(

   string Code,
   IList<ProductUnit> ProductUnits
    
    );
