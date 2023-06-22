using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllProductByCategoryId;

public sealed record GetAllProductByCategoryIdQuery(
      string CompanyId,
    
      int Id
        
    ) : IQuery<IList<GetAllProductByCategoryIdResponse>>;