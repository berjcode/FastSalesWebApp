using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetAll
{
    public sealed class GetAllPersonalQueryHandler : IQueryHandler<GetAllPersonalQuery, PaginationResult<GetAllPersonalQueryResponse>>
    {
        private readonly IPersonalService _personalService;
        private readonly IMapper _mapper;
        public GetAllPersonalQueryHandler(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        public async Task<PaginationResult<GetAllPersonalQueryResponse>> Handle(GetAllPersonalQuery request, CancellationToken cancellationToken)
        {
            
            PaginationResult<Personal> result = await _personalService.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize);

            if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

            int count = _personalService.GetCount(request.CompanyId);
            PaginationResult<GetAllPersonalQueryResponse> response = new(
                    pageNumber: request.PageNumber,
                    pageSize: request.PageSize,
                    totalCount: count,
                    datas: result.Datas.Select(
                            s => new GetAllPersonalQueryResponse(
                                    s.Id,
                                    s.Code,
                                    s.Name,
                                    s.Email,
                                    s.Department.Name
                                )).ToList()
                                );

            return response;
        }
    }
}
