using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.CreateProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.RemoveProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.UpdateProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetAllProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetByIdProductTransaction;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.ProductTransactionRepositories;
using QuickSalesApp.Domain.Repositories.Company.TransactionTypeRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Utilities;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class ProductTransactionService : IProductTransactionService
{

    private readonly IProductTransactionCommandRepository _commandRepository;
    private readonly IProductTransactionQueryRepository _queryRepository;
    private readonly ITransactionTypeQueryRepository _transactionTypeQueryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IMapper _mapper;

    public ProductTransactionService(IMapper mapper, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, IProductTransactionQueryRepository queryRepository, IProductTransactionCommandRepository commandRepository, ITransactionTypeQueryRepository transactionTypeQueryRepository)
    {
        _mapper = mapper;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _contextService = contextService;
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
        _transactionTypeQueryRepository = transactionTypeQueryRepository;
    }
    private CompanyDbContext _context;

    public async Task<ProductTransaction> ChangeState(ProductTransaction productTransaction, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(productTransaction);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return productTransaction;
    }

    public async Task CreateAsync(CreateProductTransactionCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _transactionTypeQueryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductTransaction transaction = _mapper.Map<ProductTransaction>(request);

        var res = await _transactionTypeQueryRepository.GetAll().ToListAsync();

        foreach (var item in res)
        {
            if(item.Id == request.ProcessTypeId)
            {
                transaction.Text = $"{request.PlugNo} Nolu {item.Name}";
            }
        }

        await _commandRepository.AddAsync(transaction, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<ProductTransaction>> GetAllActive(GetAllProductTransactionQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        if (request.search != null)
        {
            var queryGetAllSearch = _queryRepository.GetAll().Where(p => p.CompanyId == request.CompanyId && p.IsDelete == false && p.PlugNo.Contains(request.search))
           .Include(p => p.TransactionType);
            var resultGetAllSearch = await queryGetAllSearch.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAllSearch;
        }
        if (request.Expression == null)
        {
            var queryGetAll = _queryRepository.GetAll().Where(p => p.CompanyId == request.CompanyId && p.IsDelete == false)
           .Include(p => p.TransactionType);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }
        var newExpression = ExpressionParser.ParseExpression<ProductTransaction>(request.Expression);
        var query = _queryRepository.GetAll().Where(p => p.CompanyId == request.CompanyId && p.IsDelete == false)
            .Where(newExpression).Include(p => p.TransactionType);
        var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<ProductTransaction> GetByIdAsync(int id, string companyId)
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

    public async Task<ProductTransaction> RemoveByIdHard(RemoveProductTransactionCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductTransaction transaction = await _queryRepository.GetById(request.id);
        await _commandRepository.RemoveById(request.id);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return transaction;
    }

    public async Task<ProductTransaction> RemoveByIdSoft(string companyId, ProductTransaction transaction)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(transaction);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return transaction;
    }

    public async Task<ProductTransaction> UpdateAsync(UpdateProductTransactionCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductTransaction transaction = _mapper.Map<ProductTransaction>(request);
        _commandRepository.Update(transaction);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return transaction;
    }

    public async Task<GetByIdProductTransactionQueryResponse> GetProductTransaction(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var productType = await _queryRepository.GetWhere(x => x.Id == id).Include(p => p.TransactionType).FirstOrDefaultAsync();
        var response = _mapper.Map<GetByIdProductTransactionQueryResponse>(productType);
        return response;
    }
}
