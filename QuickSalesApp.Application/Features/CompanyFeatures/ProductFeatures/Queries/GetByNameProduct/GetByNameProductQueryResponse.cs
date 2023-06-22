using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByNameProduct
{
    public sealed record GetByNameProductQueryResponse(
            Product Product
        );
}
