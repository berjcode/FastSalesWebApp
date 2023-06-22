using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetAllSafeTransaction;

public sealed class GetAllSafeTransactionQueryHandler : IQueryHandler<GetAllSafeTransactionQuery, PaginationResult<GetAllSafeTransactionQueryResponse>>
{
    private readonly ISafeTransactionService _transactionService;

    public GetAllSafeTransactionQueryHandler(ISafeTransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<PaginationResult<GetAllSafeTransactionQueryResponse>> Handle(GetAllSafeTransactionQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<SafeTransaction> result = await _transactionService.GetAllActive(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _transactionService.GetCount(request.CompanyId);
        PaginationResult<GetAllSafeTransactionQueryResponse> response = new(
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                totalCount: count,
                datas: result.Datas.Select(
                        s => new GetAllSafeTransactionQueryResponse(
                                Id: s.Id,
                                PlugNo: s.PlugNo,
                                SafeCode: s.SafeCode,
                                TransactionDate: s.TransactionDate,
                                Text: s.Text,
                                Debt: s.Debt,
                                Credit: s.Credit,
                                Remainder: s.Remainder,
                                ProcessTypeName: s.TransactionTypes.Name,
                                CompanyId: s.CompanyId
                            )).ToList());

        return response;
    }
}
