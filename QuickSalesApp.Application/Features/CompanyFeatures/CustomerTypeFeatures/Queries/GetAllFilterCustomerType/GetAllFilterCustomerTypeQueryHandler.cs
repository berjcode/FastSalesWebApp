using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllFilterCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllCustomerType;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;


namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllFilterCustomerType;

public sealed class GetAllFilterCustomerTypeQueryHandler : IQueryHandler<GetAllFilterCustomerTypeQuery, PaginationResult<GetAllFilterCustomerTypeQueryResponse>>
{
    private readonly ICustomerTypeService _customerTypeService;
    private readonly IMapper _mapper;

    public GetAllFilterCustomerTypeQueryHandler(ICustomerTypeService customerTypeService, IMapper mapper)
    {
        _customerTypeService = customerTypeService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllFilterCustomerTypeQueryResponse>> Handle(GetAllFilterCustomerTypeQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<CustomerType> result = await _customerTypeService.GetAllFilter(request);

        if (result == null || result.Datas == null)
            throw new Exception("Herhangi bir veri bulunamadı");


        int count = _customerTypeService.GetCountByFilter(request.CompanyId, request.Expression);
        PaginationResult<GetAllFilterCustomerTypeQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllFilterCustomerTypeQueryResponse(
                s.Id, s.Name, 
                s.IsActive, s.CreatorName, s.CreatedDate, s.UpdaterName, s.UpdateDate


                )).ToList());




        return newResult;




    }
}
