using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllCustomerType;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;


namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllActiveCustomerType;

public sealed class GetAllActiveCustomerTypeQueryHandler : IQueryHandler<GetAllActiveCustomerTypeQuery, GetAllActiveCustomerTypeQueryResponse>
{
    private readonly ICustomerTypeService _customerTypeService;
    private readonly IMapper _mapper;

    public GetAllActiveCustomerTypeQueryHandler(ICustomerTypeService customerTypeService, IMapper mapper)
    {
        _customerTypeService = customerTypeService;
        _mapper = mapper;
    }

    public async Task<GetAllActiveCustomerTypeQueryResponse> Handle(GetAllActiveCustomerTypeQuery request, CancellationToken cancellationToken)
    {
                 var result = await _customerTypeService.GetAllActive(request.CompanyId);



        GetAllActiveCustomerTypeQueryResponse newResult = _mapper.Map<GetAllActiveCustomerTypeQueryResponse>(result);





        return newResult;




    }
}
