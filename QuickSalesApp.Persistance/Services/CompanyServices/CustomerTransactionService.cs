

using AutoMapper;
using Azure.Core;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.CreateCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.UpdateCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetAllFilterCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.CustomerTransactionRepositories;
using QuickSalesApp.Domain.Repositories.Company.DepartmentRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Utilities;
using System.Linq.Expressions;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class CustomerTransactionService : ICustomerTransactionService
{

    private readonly ICustomerTransactionCommandRepository _commandRepository;
    private readonly ICustomerTransactionQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private CompanyDbContext _context;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomerTransactionService(ICustomerTransactionCommandRepository commandRepository,
        ICustomerTransactionQueryRepository queryRepository,
        IContextService contextService,
        ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CustomerTransaction> ChangeState(string companyId, CustomerTransaction customerTransaction)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(customerTransaction);
        await _unitOfWork.SaveChangesAsync();

        return customerTransaction;
    }

    public async Task CreateAsync(CreateCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        CustomerTransaction customerTransaction = _mapper.Map<CustomerTransaction>(request);


        await _commandRepository.AddAsync(customerTransaction, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<CustomerTransaction>> GetAllActive(string companyId, int PageNumber, int PageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(PageNumber, PageSize);

        return result;
    }

    public async Task<CustomerTransaction> GetByIdAsync(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetById(id);
    }

    public async Task<CustomerTransaction> GetByCodeAsync(string companyId, string customerCode)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.CustomerCode == customerCode);
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public async Task<GetCustomerTransactionQueryResponse> GetCustomerTransaction(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var customerTransaction = await _queryRepository.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
        var response = _mapper.Map<GetCustomerTransactionQueryResponse>(customerTransaction);
        return response;
    }

    public async Task<CustomerTransaction> RemoveByIdHard(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        CustomerTransaction customerTransaction = await _queryRepository.GetById(id);
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
        return customerTransaction;
    }

    public async Task<CustomerTransaction> RemoveByIdSoft(string companyId, CustomerTransaction customerTransaction)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(customerTransaction);
        await _unitOfWork.SaveChangesAsync();

        return customerTransaction;
    }

    public async Task<CustomerTransaction> UpdateAsync(UpdateCustomerTransactionCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        CustomerTransaction newCustomerTransaction = _mapper.Map<CustomerTransaction>(request);
        newCustomerTransaction.UpdateDate = DateTime.Now;
        _commandRepository.Update(newCustomerTransaction);
        await _unitOfWork.SaveChangesAsync();

        return newCustomerTransaction;
    }

    public async Task<PaginationResult<CustomerTransaction>> GetAllFilter(GetAllFilterCustomerTransactionQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        if (request.search != null)
        {
            var queryGetAllSearch = _queryRepository.GetAll().Where(p => p.CompanyId == request.CompanyId && p.IsDelete == false && p.PlugNo.Contains(request.search))
           .Include(p => p.TransactionTypes);
            var resultGetAllSearch = await queryGetAllSearch.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAllSearch;
        }
        if (request.Expression == null)
        {
            var queryGetAll = _queryRepository.GetAll().Where(p => p.CompanyId == request.CompanyId && p.IsDelete == false)
           .Include(p => p.TransactionTypes);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }
        var newExpression = ExpressionParser.ParseExpression<CustomerTransaction>(request.Expression);
        var query = _queryRepository.GetAll().Where(p => p.CompanyId == request.CompanyId && p.IsDelete == false)
            .Where(newExpression).Include(p => p.TransactionTypes);
        var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

   
    public int GetCountByFilter(string companyId, string expression, string search)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        if (expression == null)
            return _queryRepository.GetAll().Count();
        var newExpression = ExpressionParser.ParseExpression<CustomerTransaction>(expression);
        if (search == null && expression != null)
            return _queryRepository.GetAll().Where(newExpression).Count();

        return _queryRepository.GetAll().Where(x => x.PlugNo == search).Count();
    }
}
