using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllUnit;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetAllTransactionType;

public sealed class GetAllTransactionTypeQueryHandler : IQueryHandler<GetAllTransactionTypeQuery, PaginationResult<GetAllTransactionTypeQueryResponse>>
{
    private readonly ITransactionTypeService _transactionTypeService;
    private readonly IMapper _mapper;

    public GetAllTransactionTypeQueryHandler(ITransactionTypeService transactionTypeService, IMapper mapper)
    {
        _transactionTypeService = transactionTypeService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllTransactionTypeQueryResponse>> Handle(GetAllTransactionTypeQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<TransactionType> result = await _transactionTypeService.GetAllActive(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _transactionTypeService.GetCount(request.CompanyId);
        PaginationResult<GetAllTransactionTypeQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllTransactionTypeQueryResponse>(s)).ToList()
            );


        return newResult;
    }
}
