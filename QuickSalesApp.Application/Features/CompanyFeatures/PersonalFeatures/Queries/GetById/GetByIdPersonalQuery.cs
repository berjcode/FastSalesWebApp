using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetById
{
    public sealed record GetByIdPersonalQuery(
            int PersonalId,
            string CompanyId
        ) : IQuery<GetByIdPersonalQueryResponse>;
}
