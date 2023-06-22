using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetAllFilterCustomerTransaction;

public sealed class GetAllFilterCustomerTransactionQueryHandler : IQueryHandler<GetAllFilterCustomerTransactionQuery, PaginationResult<GetAllFilterCustomerTransactionQueryResponse>>
{

    private readonly ICustomerTransactionService _customerTransactionService;
    private readonly IMapper _mapper;

    public GetAllFilterCustomerTransactionQueryHandler(ICustomerTransactionService customerTransactionService, IMapper mapper)
    {

        _customerTransactionService = customerTransactionService;
        _mapper = mapper;
    }
    public async Task<PaginationResult<GetAllFilterCustomerTransactionQueryResponse>> Handle(GetAllFilterCustomerTransactionQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<CustomerTransaction> result = await _customerTransactionService.GetAllFilter(request);

        if (result == null || result.Datas== null) throw new Exception(ExceptionMessage.NullDataException);
        int count = _customerTransactionService.GetCountByFilter(request.CompanyId,request.Expression,request.search);

        PaginationResult<GetAllFilterCustomerTransactionQueryResponse> newResult = new(
          pageNumber: request.PageNumber,
          pageSize: request.PageSize,
          totalCount: count,
          datas: result.Datas.Select(s => new GetAllFilterCustomerTransactionQueryResponse(
              s.Id, s.PlugNo, s.CustomerCode, s.TransactionDate, s.Text, s.Description, s.Debt, s.Credit,
              s.Remainder, s.ProcessTypeId,s.TransactionTypes.Name, s.CreatorName, s.CreatedDate,
              s.UpdaterName, s.UpdateDate,
              s.IsActive


              )).ToList());

        



        return newResult;
    }
}
