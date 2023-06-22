using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.CreateTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.RemoveTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.UpdateTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetAllTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetTransactionType;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.TransactionTypeRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class TransactionTypeService : ITransactionTypeService
{
    private readonly ITransactionTypeCommandRepository _commandRepository;
    private readonly ITransactionTypeQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IMapper _mapper;

    public TransactionTypeService(IMapper mapper, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, ITransactionTypeQueryRepository queryRepository, ITransactionTypeCommandRepository commandRepository)
    {
        _mapper = mapper;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _contextService = contextService;
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }

    private CompanyDbContext _context;


    public async Task<TransactionType> ChangeState(TransactionType transactionType, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(transactionType);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return transactionType;
    }

    public async Task CreateAsync(CreateTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        TransactionType type = _mapper.Map<TransactionType>(request);

        await _commandRepository.AddAsync(type, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<TransactionType>> GetAllActive(GetAllTransactionTypeQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<TransactionType> GetByIdAsync(int Id, string CompanyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetById(Id);
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public async Task<GetTransactionTypeQueryResponse> GetTransactionType(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var unit = await _queryRepository.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
        var response = _mapper.Map<GetTransactionTypeQueryResponse>(unit);
        return response;
    }

    public async Task<TransactionType> RemoveByIdHard(RemoveTransactionTypeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        TransactionType type = await _queryRepository.GetById(request.id);
        await _commandRepository.RemoveById(request.id);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return type;
    }

    public async Task<TransactionType> RemoveByIdSoft(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        TransactionType type = await _queryRepository.GetById(id);
        type.IsActive = false;
        type.IsDelete = true;
        _commandRepository.Update(type);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return type;
    }

    public async Task<TransactionType> UpdateAsync(UpdateTransactionTypeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        TransactionType type = _mapper.Map<TransactionType>(request);
        _commandRepository.Update(type);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return type;
    }
}
