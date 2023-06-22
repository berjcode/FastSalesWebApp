using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetByIdProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.CreateSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.RemoveSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.UpdateSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetAllSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetSafeTransaction;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.ProductTransactionRepositories;
using QuickSalesApp.Domain.Repositories.Company.SafeTransactionRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class SafeTransactionService : ISafeTransactionService
{
    private readonly ISafeTransactionCommandRepository _commandRepository;
    private readonly ISafeTransactionQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IMapper _mapper;

    public SafeTransactionService(IMapper mapper, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, ISafeTransactionQueryRepository queryRepository, ISafeTransactionCommandRepository commandRepository)
    {
        _mapper = mapper;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _contextService = contextService;
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }
    private CompanyDbContext _context;

    public async Task<SafeTransaction> ChangeState(SafeTransaction safeTransaction, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(safeTransaction);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return safeTransaction;
    }

    public async Task CreateAsync(CreateSafeTransactionCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        SafeTransaction transaction = _mapper.Map<SafeTransaction>(request);

        await _commandRepository.AddAsync(transaction, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<SafeTransaction>> GetAllActive(GetAllSafeTransactionQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true).OrderByDescending(p => p.CreatedDate).Include(p => p.TransactionTypes).ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<SafeTransaction> GetByIdAsync(int id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetById(id);
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public async Task<GetSafeTransactionQueryResponse> GetSafeTransaction(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var productType = await _queryRepository.GetWhere(x => x.Id == id).Include(p => p.TransactionTypes).FirstOrDefaultAsync();
        var response = _mapper.Map<GetSafeTransactionQueryResponse>(productType);
        return response;
    }

    public async Task<SafeTransaction> RemoveByIdHard(RemoveSafeTransactionCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        SafeTransaction transaction = await _queryRepository.GetById(request.id);
        await _commandRepository.RemoveById(request.id);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return transaction;
    }

    public async Task<SafeTransaction> RemoveByIdSoft(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        SafeTransaction transaction = await _queryRepository.GetById(id);
        transaction.IsActive = false;
        transaction.IsDelete = true;
        _commandRepository.Update(transaction);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return transaction;
    }

    public async Task<SafeTransaction> UpdateAsync(UpdateSafeTransactionCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        SafeTransaction transaction = _mapper.Map<SafeTransaction>(request);
        _commandRepository.Update(transaction);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return transaction;
    }
}
