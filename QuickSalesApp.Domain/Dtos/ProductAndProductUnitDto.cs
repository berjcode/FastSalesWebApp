using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using System.Xml.Linq;

namespace QuickSalesApp.Domain.Dtos;

public sealed  record ProductAndProductUnitDto(
                int Id,
                string Name,
            string Code,
            string UrlPhoto,
            int VatTypeValue,
    IList<ProductUnitDto> ProductUnits
    );
