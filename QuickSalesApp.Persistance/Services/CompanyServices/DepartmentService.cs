using AutoMapper;
using Azure.Core;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.CreateDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.UpdateDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.DepartmentRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using System.Security.Cryptography.X509Certificates;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class DepartmentService : IDepartmentService
{

    private readonly IDepartmentCommandRepository _commandRepository;
    private readonly IDepartmentQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private CompanyDbContext _context;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentCommandRepository commandRepository,
        IDepartmentQueryRepository queryRepository,
        IContextService contextService,

        ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _contextService = contextService;

        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginationResult<Department>> GetAllActive(string companyId, int PageNumber, int PageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(PageNumber, PageSize);

        return result;
    }
    public async Task CreateAsync(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Department department = _mapper.Map<Department>(request);


        await _commandRepository.AddAsync(department, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<GetDepartmentQueryResponse> GetDepartment(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var department = await _queryRepository.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
        var response = _mapper.Map<GetDepartmentQueryResponse>(department);
        return response;
    }
    public async Task<Department> GetByNameAsync(string companyId, string name)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.Name == name);
    }

    public async Task<Department> GetByIdAsync(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetById(id);
    }

    public async Task<Department> RemoveByIdHard(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Department department = await _queryRepository.GetById(id);
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
        return department;
    }

    public async Task<Department> RemoveByIdSoft(string companyId, Department department)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(department);
        await _unitOfWork.SaveChangesAsync();

        return department;
    }

    public async Task<Department> UpdateAsync(UpdateDepartmentCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Department newDepartment = _mapper.Map<Department>(request);
        newDepartment.UpdateDate = DateTime.Now;
        _commandRepository.Update(newDepartment);
        await _unitOfWork.SaveChangesAsync();

        return newDepartment;
    }



    public async Task<Department> ChangeState(string companyId, Department department)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(department);
        await _unitOfWork.SaveChangesAsync();

        return department;
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }
}
