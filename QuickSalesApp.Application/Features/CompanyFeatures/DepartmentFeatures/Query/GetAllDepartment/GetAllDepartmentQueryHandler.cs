using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetAllDepartment;

public sealed class GetAllDepartmentQueryHandler : IQueryHandler<GetAllDepartmentQuery, PaginationResult<GetAllDepartmentQueryResponse>>
{
    private readonly IDepartmentService _departmentService;
    private readonly IMapper _mapper;

    public GetAllDepartmentQueryHandler(IDepartmentService departmentService, IMapper mapper)
    {
        _departmentService = departmentService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllDepartmentQueryResponse>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Department> result = await _departmentService.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize);


        int count = _departmentService.GetCount(request.CompanyId);
        PaginationResult<GetAllDepartmentQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllDepartmentQueryResponse>(s)).ToList()
            ) ;


        return newResult;




    }
}
