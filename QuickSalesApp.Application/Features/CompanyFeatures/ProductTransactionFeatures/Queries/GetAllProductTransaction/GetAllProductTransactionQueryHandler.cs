using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetAllProductTransaction;

public sealed class GetAllProductTransactionQueryHandler : IQueryHandler<GetAllProductTransactionQuery, PaginationResult<GetAllProductTransactionQueryResponse>>
{
    private readonly IProductTransactionService _service;

    public GetAllProductTransactionQueryHandler(IProductTransactionService service)
    {
        _service = service;
    }

    public async Task<PaginationResult<GetAllProductTransactionQueryResponse>> Handle(GetAllProductTransactionQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<ProductTransaction> result = await _service.GetAllActive(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _service.GetCount(request.CompanyId);
        PaginationResult<GetAllProductTransactionQueryResponse> response = new(
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                totalCount: count,
                datas: result.Datas.Select(
                        s => new GetAllProductTransactionQueryResponse(
                                Id: s.Id,
                                PlugNo: s.PlugNo,
                                ProductCode: s.ProductCode,
                                Text: s.Text,
                                TransactionDate: s.TransactionDate.ToString(),
                                EnteringQuantity: s.EnteringQuantity,
                                OutgoingQuantity: s.OutgoingQuantity,
                                Remainder: s.Remainder,
                                ProcessTypeName: s.TransactionType.Name,
                                IsActive: s.IsActive,
                                ProcessTypeId: s.ProcessTypeId
                            )).ToList());

        return response;
    }
    
}
