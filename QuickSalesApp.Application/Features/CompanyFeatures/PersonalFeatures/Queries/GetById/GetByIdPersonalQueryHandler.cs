using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetById
{
    public sealed class GetByIdPersonalQueryHandler : IQueryHandler<GetByIdPersonalQuery, GetByIdPersonalQueryResponse>
    {
        private readonly IPersonalService _personalService;

        public GetByIdPersonalQueryHandler(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        public async Task<GetByIdPersonalQueryResponse> Handle(GetByIdPersonalQuery request, CancellationToken cancellationToken)
        {
            var result = await _personalService.GetPersonal(request.CompanyId, request.PersonalId);
            if (result == null) throw new Exception(ExceptionMessage.NullDataException);
            return result;
        }
    }
}
