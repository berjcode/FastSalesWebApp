using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllFilterCustomer;

public sealed class GetAllFilterCustomerQueryHandler : IQueryHandler<GetAllFilterCustomerQuery, PaginationResult<GetAllFilterCustomerQueryResponse>>
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public GetAllFilterCustomerQueryHandler(IMapper mapper, ICustomerService customerService)
    {

        _mapper = mapper;
        _customerService = customerService;
    }

    public async Task<PaginationResult<GetAllFilterCustomerQueryResponse>> Handle(GetAllFilterCustomerQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Customer> result = await _customerService.GetAllFilter(request);

        if (result == null || result.Datas == null)
            throw new Exception(ExceptionMessage.NullDataException);

        int count = _customerService.GetCountbyFilter(request.CompanyId, request.Expression,request.search);
        PaginationResult<GetAllFilterCustomerQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllFilterCustomerQueryResponse(
                s.Id, s.Code, s.Name, s.GroupCode, s.CustomerTypeId, s.CustomerType.Name, s.CellPhone1, s.CellPhone2, s.Telephone,
                s.Email, s.TaxOffice, s.TaxNumber, s.Address, s.Address2, s.SPECode1, s.SPECode2, s.SPECode3,
                s.SPECode4, s.SPECode5,
                s.IsActive, s.CompanyId, s.CreatorName, s.CreatedDate, s.UpdaterName, s.UpdateDate,s.City,s.Town,
                count

                )).ToList());


       

        return newResult;
    }
}
