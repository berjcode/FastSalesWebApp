using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos.SalesBasketDtoClient;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetBasketUnit;

public sealed record GetBasketUnitQueryResponse(
       IList<UnitListDto> Unit

    );