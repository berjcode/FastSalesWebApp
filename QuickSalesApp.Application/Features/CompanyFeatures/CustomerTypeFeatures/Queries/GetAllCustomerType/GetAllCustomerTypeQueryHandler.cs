using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;


namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllCustomerType;

public sealed class GetAllCustomerTypeQueryHandler : IQueryHandler<GetAllCustomerTypeQuery, PaginationResult<GetAllCustomerTypeQueryResponse>>
{
    private readonly ICustomerTypeService _customerTypeService;
    private readonly IMapper _mapper;

    public GetAllCustomerTypeQueryHandler(ICustomerTypeService customerTypeService, IMapper mapper)
    {
        _customerTypeService = customerTypeService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllCustomerTypeQueryResponse>> Handle(GetAllCustomerTypeQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<CustomerType> result = await _customerTypeService.GetAll(request.CompanyId, request.PageNumber, request.PageSize);


        int count = _customerTypeService.GetCount(request.CompanyId);
        PaginationResult<GetAllCustomerTypeQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllCustomerTypeQueryResponse>(s)).ToList()
            ) ;


        return newResult;




    }
}
