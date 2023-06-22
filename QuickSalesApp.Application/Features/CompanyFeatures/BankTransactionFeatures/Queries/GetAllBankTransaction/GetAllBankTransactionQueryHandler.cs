using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetAllSafeTransaction;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetAllBankTransaction;

public sealed class GetAllBankTransactionQueryHandler : IQueryHandler<GetAllBankTransactionQuery, PaginationResult<GetAllBankTransactionQueryResponse>>
{ 
    private readonly IBankTransactionService _bankTransactionService;

    public GetAllBankTransactionQueryHandler(IBankTransactionService bankTransactionService)
    {
        _bankTransactionService = bankTransactionService;
    }

    public async Task<PaginationResult<GetAllBankTransactionQueryResponse>> Handle(GetAllBankTransactionQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<BankTransaction> result = await _bankTransactionService.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize);

        int count = _bankTransactionService.GetCount(request.CompanyId);
        PaginationResult<GetAllBankTransactionQueryResponse> response = new(
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                totalCount: count,
                datas: result.Datas.Select(
                        s => new GetAllBankTransactionQueryResponse(
                                 s.Id,
                               s.PlugNo,
                               s.BankCode,
                              s.TransactionDate,
                                s.Text,
                                 s.Debt,
                                s.Credit,
                                 s.Remainder,
                                s.ProcessTypeId,
                                 s.CompanyId,
                                 s.CreatorName, s.CreatedDate,
                             s.UpdaterName, s.UpdateDate,
                            s.IsActive
                            )).ToList());

        return response;
    }
}
