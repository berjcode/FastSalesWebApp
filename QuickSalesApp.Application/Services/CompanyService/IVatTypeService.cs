using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.CreateVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.RemoveVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.UpdateVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllActiveVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllFilterVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetVatType;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos.ProductOptions;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface IVatTypeService
{
    Task CreateAsync(CreateVatTypeCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<VatType>> GetAllActive(GetAllActiveVatTypeQuery request);
    Task<PaginationResult<VatType>> GetAll(GetAllVatTypeQuery request);
    Task<VatType> GetByIdAsync(int Id, string CompanyId);
    Task<VatType> GetByNameAsync(string name, string CompanyId);
    Task<VatType> RemoveByIdHard(RemoveVatTypeCommand request);
    Task<VatType> RemoveByIdSoft(string companyId, VatType vatType);
    Task<VatType> ChangeState(VatType vatType, string companyId);
    Task<VatType> UpdateAsync(UpdateVatTypeCommand request);
    int GetCount(string companyId);
    Task<GetVatTypeQueryResponse> GetVatType(string companyId, int id);
    Task<PaginationResult<VatType>> GetAllFilter(GetAllFilterVatTypeQuery request);
    int GetCountbyFilter(string companyId, string expression);
    Task<ProductOptionsGetByIdDto> GetByIdForCheck(string companyId, int id);
}
