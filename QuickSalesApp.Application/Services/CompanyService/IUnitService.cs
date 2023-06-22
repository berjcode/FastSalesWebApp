using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.CreateUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.RemoveUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.UpdateUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllActiveUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllFilterUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetBasketUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetUnit;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos.ProductOptions;
using QuickSalesApp.Domain.Dtos.SalesBasketDtoClient;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface IUnitService
{
    Task CreateAsync(CreateUnitCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<Unit>> GetAllActive(GetAllActiveUnitQuery request);
    Task<IList<Unit>> GetBasketUnit(GetBasketUnitQuery request);
    Task<Unit> GetByIdAsync(int Id, string CompanyId);
    Task<Unit> GetByNameAsync(string Name, string CompanyId);
    Task<Unit> RemoveByIdHard(RemoveUnitCommand request);
    Task<Unit> RemoveByIdSoft(string companyId, Unit unit);
    Task<Unit> ChangeState(Unit unit, string companyId);
    Task<Unit> UpdateAsync(UpdateUnitCommand request);
    int GetCount(string companyId);
    Task<GetUnitQueryResponse> GetUnit(string companyId, int id);
    Task<PaginationResult<Unit>> GetAll(GetAllUnitQuery request);
    Task<PaginationResult<Unit>> GetAllFilter(GetAllFilterUnitQuery request);
    int GetCountbyFilter(string companyId, string expression);
    Task<ProductOptionsGetByIdDto> GetByIdForCheck(string companyId, int id);
}
