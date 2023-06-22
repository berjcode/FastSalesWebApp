

using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.CreateCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.UpdateCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllFilterCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetCustomerType;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.CustomerTypeRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Utilities;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class CustomerTypeService : ICustomerTypeService
{

    private readonly ICustomerTypeCommandRepository _commandRepository;
    private readonly ICustomerTypeQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private CompanyDbContext _context;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomerTypeService(ICustomerTypeCommandRepository commandRepository,
        ICustomerTypeQueryRepository queryRepository,
        IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        CustomerType customerType = _mapper.Map<CustomerType>(request);


        await _commandRepository.AddAsync(customerType, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<CustomerType> GetByNameAsync(string companyId, string name)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.Name == name);
    }

    public Task<GetCustomerTypeQueryResponse> GetDepartment(string companyId, int id)
    {
        throw new NotImplementedException();
    }

    public async Task<CustomerType> GetByIdAsync(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetById(id);
    }

    public async Task<CustomerType> RemoveByIdHard(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        CustomerType customerType = await _queryRepository.GetById(id);
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
        return customerType;
    }

    public async Task<CustomerType> RemoveByIdSoft(string companyId, CustomerType customerType)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(customerType);
        await _unitOfWork.SaveChangesAsync();

        return customerType;
    }

    public async Task<CustomerType> UpdateAsync(UpdateCustomerTypeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        CustomerType newCustomerType = _mapper.Map<CustomerType>(request);
        newCustomerType.UpdateDate = DateTime.Now;
        _commandRepository.Update(newCustomerType);
        await _unitOfWork.SaveChangesAsync();

        return newCustomerType;
    }

    public async Task<PaginationResult<CustomerType>> GetAll(string companyId, int PageNumber, int PageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsDelete == false).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(PageNumber, PageSize);

        return result;
    }

    public async Task<IList<CustomerType>> GetAllActive(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false).ToListAsync();

        return result;
    }

    public async Task<CustomerType> ChangeState(string companyId, CustomerType customerType)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(customerType);
        await _unitOfWork.SaveChangesAsync();

        return customerType;
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public int GetCountByFilter(string companyId, string expression)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        if (expression == null)
            return _queryRepository.GetAll().Count();

        var newExpression = ExpressionParser.ParseExpression<CustomerType>(expression);
        return _queryRepository.GetAll().Where(p => p.IsDelete == false).Where(newExpression).OrderBy(p => p.Id).Count();
    }

    public async Task<PaginationResult<CustomerType>> GetAllFilter(GetAllFilterCustomerTypeQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        if (request.Expression == null)
        {
            var queryGetAll = await _queryRepository.GetAll().Where(p => p.IsDelete == false).ToPagedListAsync(request.PageNumber, request.PageSize);
            return queryGetAll;
        }
        var expression = ExpressionParser.ParseExpression<CustomerType>(request.Expression);
        var query = await _queryRepository.GetAll().Where(p => p.IsDelete == false)
         .Where(expression).ToPagedListAsync(request.PageNumber, request.PageSize);

        return query;
    }
}
