using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.CreatePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.RemovePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.UpdatePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetById;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService
{
    public interface IPersonalService
    {
        Task CreateAsync(CreatePersonalCommand request, CancellationToken cancellationToken);
        Task<Personal> UpdateAsync(UpdatePersonalCommand request);
        Task<Personal> RemoveByIdHard(RemovePersonalCommand request);
        Task<Personal> RemoveByIdSoft(string companyId, int id);
        Task<PaginationResult<Personal>> GetAllActive(string companyId, int PageNumber, int PageSize);
        Task<Personal> GetByIdAsync(int personalId, string CompanyId);
        Task<Personal> GetByEmailAsync(string email, string CompanyId);
        Task<Personal> ChangeState(Personal personal, string companyId);
        int GetCount(string companyId);
        Task<GetByIdPersonalQueryResponse> GetPersonal(string companyId, int id);
    }
}
