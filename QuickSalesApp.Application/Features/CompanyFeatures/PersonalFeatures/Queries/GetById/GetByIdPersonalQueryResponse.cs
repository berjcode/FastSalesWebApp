namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetById
{
    public sealed record GetByIdPersonalQueryResponse(
            string Code,
            string Name,
            string Email,
            string CreatorName,
            string DepartmentName,
            DateTime? CreatedDate,
            string UpdaterName,
            DateTime? UpdateDate,
            bool? IsActive
        );
}
