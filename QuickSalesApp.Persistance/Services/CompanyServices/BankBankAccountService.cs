using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.BankBankAccountFeatures.Queries.GetBankBankAccount;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.BankBankAccountRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class BankBankAccountService : IBankBankAccountService
{
    private readonly IBankBankAccountCommandRepository _commandRepository;
    private readonly IBankBankAccountQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private CompanyDbContext _context;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BankBankAccountService(IBankBankAccountCommandRepository commandRepository, 
        IBankBankAccountQueryRepository queryRepository, 
        IContextService contextService,
        ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BankBankAccount> ChangeState(string companyId, BankBankAccount bankBankAccount)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(bankBankAccount);
        await _unitOfWork.SaveChangesAsync();

        return bankBankAccount;
    }

    public async Task CreateAsync(BankBankAccount bankBankAccount,CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(bankBankAccount.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        //BankBankAccount bankBankAccount = _mapper.Map<BankBankAccount>(request);


        await _commandRepository.AddAsync(bankBankAccount, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<BankBankAccount>> GetAllActive(string companyId, int PageNumber, int PageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(PageNumber, PageSize);

        return result;
    }

    public async Task<GetBankBankAccountQueryResponse> GetBankBankAccount(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var bankBankAccount = await _queryRepository.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
        var response = _mapper.Map<GetBankBankAccountQueryResponse>(bankBankAccount);
        return response;
    }

    public async  Task<BankBankAccount> GetByIdAsync(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetById(id);
    }

    public Task<BankBankAccount> GetByNameAsync(string companyId, string name)
    {
        throw new NotImplementedException();
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public async Task<BankBankAccount> RemoveByIdHard(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        BankBankAccount bankBankAccount = await _queryRepository.GetById(id);
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
        return bankBankAccount;
    }

    public async Task<BankBankAccount> RemoveByIdSoft(string companyId, BankBankAccount bankBankAccount)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(bankBankAccount);
        await _unitOfWork.SaveChangesAsync();

        return bankBankAccount;
    }

    public async Task<BankBankAccount> UpdateAsync(BankBankAccount bankBankAccount, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        _commandRepository.Update(bankBankAccount);
        await _unitOfWork.SaveChangesAsync();

        return bankBankAccount;
    }
}
