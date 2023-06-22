using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;

public sealed class GetAllCustomerQueryHandler : IQueryHandler<GetAllCustomerQuery, PaginationResult<GetAllCustomerQueryResponse>>
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public GetAllCustomerQueryHandler(IMapper mapper, ICustomerService customerService)
    {

        _mapper = mapper;
        _customerService = customerService;
    }

    public async Task<PaginationResult<GetAllCustomerQueryResponse>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Customer> result = await _customerService.GetAll(request.CompanyId, request.PageNumber, request.PageSize);


        int count = _customerService.GetCount(request.CompanyId);
        PaginationResult<GetAllCustomerQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s=> new GetAllCustomerQueryResponse(
                s.Id ,s.Code, s.Name, s.GroupCode,s.CustomerTypeId,s.CustomerType.Name,s.CellPhone1,s.CellPhone2,s.Telephone,
                s.Email,s.TaxOffice,s.TaxNumber,s.Address,s.Address2,s.SPECode1,s.SPECode2,s.SPECode3,
                s.SPECode4,s.SPECode5,
                s.IsActive,s.CompanyId,s.CreatorName,s.CreatedDate,s.UpdaterName,s.UpdateDate,s.City,s.Town


                )).ToList());


       


        return newResult;




    }
}
