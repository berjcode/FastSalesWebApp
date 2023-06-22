using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos;
using System.Linq;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetAllBank;

public sealed class GetAllBankQueryHandler : IQueryHandler<GetAllBankQuery, PaginationResult<GetAllBankQueryResponse>>
{
    private readonly IBankService _bankService;
    private readonly IMapper _mapper;

    public GetAllBankQueryHandler(IBankService bankService, IMapper mapper)
    {
        _bankService = bankService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllBankQueryResponse>> Handle(GetAllBankQuery request, CancellationToken cancellationToken)
    {

        PaginationResult<Bank> result = await _bankService.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize);

        int count = _bankService.GetCount(request.CompanyId);
        PaginationResult<GetAllBankQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllBankQueryResponse>(s)).ToList());




        return newResult;
    }

    //public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    //{
    //    return new(await _categoryService.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize));
    //}
}
