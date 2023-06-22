using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.CreateBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.UpdateBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetBankAccount;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.BankAccountRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class BankAccountService : IBankAccountService
{

    private readonly IBankAccountCommandRepository _commandRepository;
    private readonly IBankAccountQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private CompanyDbContext _context;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IBankBankAccountService _bankBankAccountService;

    public BankAccountService(IBankAccountCommandRepository commandRepository,
        IBankAccountQueryRepository queryRepository, IContextService contextService,
        ICompanyDbUnitOfWork unitOfWork, IMapper mapper, IBankBankAccountService bankBankAccountService)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _bankBankAccountService = bankBankAccountService;
    }

    public async Task<BankAccount> ChangeState(string companyId, BankAccount bankAccount)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(bankAccount);
        await _unitOfWork.SaveChangesAsync();

        return bankAccount;
    }

    public async Task CreateAsync(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        BankAccount bankAccount = _mapper.Map<BankAccount>(request);

        await _commandRepository.AddAsync(bankAccount, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var bankAccountId = bankAccount.Id;
        var bankId =  request.BankId;
        var companyId= bankAccount.CompanyId;
        var bankBankAccount = new BankBankAccount
        {
            BankId = bankId,
            AccountId = bankAccountId,
            CompanyId = companyId
        };
        _bankBankAccountService.CreateAsync(bankBankAccount,cancellationToken);
        
    }

    public async Task<PaginationResult<BankAccount>> GetAllActive(string companyId, int PageNumber, int PageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false && p.CompanyId == companyId).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(PageNumber, PageSize);

        return result;
    }

    public async Task<GetBankAccountQueryResponse> GetBankAccount(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var bankAccount = await _queryRepository.GetWhere(x => x.Id == id && x.CompanyId == companyId).FirstOrDefaultAsync();
        var response = _mapper.Map<GetBankAccountQueryResponse>(bankAccount);
        return response;
    }

    public async Task<BankAccount> GetByIdAsync(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetById(id);
    }

    public async Task<BankAccount> GetByNameAsync(string companyId, string name)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.Name == name);
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public async Task<BankAccount> RemoveByIdHard(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        BankAccount bankAccount = await _queryRepository.GetById(id);
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
        return bankAccount;
    }

    public async Task<BankAccount> RemoveByIdSoft(string companyId, BankAccount bankAccount)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(bankAccount);
        await _unitOfWork.SaveChangesAsync();

        return bankAccount;
    }

    public async Task<BankAccount> UpdateAsync(UpdateBankAccountCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        BankAccount bankAccount = _mapper.Map<BankAccount>(request);
        _commandRepository.Update(bankAccount);
        await _unitOfWork.SaveChangesAsync();

        return bankAccount;
    }
}
