namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetAll
{
    public sealed record GetAllPersonalQueryResponse(
            int Id,
            string Code,
            string Name,
            string email,
            string DepartmanName
        );
}
