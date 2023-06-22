

using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.CreateCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.UpdateCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetCurrency;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface ICurrencyService
{
    Task CreateAsync(CreateCurrencyCommand request, CancellationToken cancellationToken);
    Task<Currency> GetByNameAsync(string companyId, string name);
    Task<GetCurrencyQueryResponse> GetCurrency(string companyId, int id);
    Task<Currency> GetByIdAsync(string companyId, int id);
    Task<Currency> RemoveByIdHard(string companyId, int id);
    Task<Currency> RemoveByIdSoft(string companyId, Currency currency);
    Task<Currency> UpdateAsync(UpdateCurrencyCommand request);
    Task<PaginationResult<Currency>> GetAllActive(string companyId, int pageNumber, int pageSize);

    Task<Currency> ChangeState(string companyId, Currency currency);

    int GetCount(string companyId);
}
