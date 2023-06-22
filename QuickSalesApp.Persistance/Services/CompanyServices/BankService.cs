using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.CreateBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.UpdateBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetBank;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.BankRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class BankService : IBankService
{

    private readonly IBankCommandRepository _commandRepository;
    private readonly IBankQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private CompanyDbContext _context;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BankService(
        IBankCommandRepository commandRepository,
        IBankQueryRepository queryRepository,
        IContextService contextService,
        ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateBankCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Bank bank = _mapper.Map<Bank>(request);


        await _commandRepository.AddAsync(bank, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);



    }

    public async Task<Bank> GetByNameAsync(string companyId, string name)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.Name == name);
    }

    public async Task<GetBankQueryResponse> GetBank(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var bank = await _queryRepository.GetWhere(x => x.Id == id && x.CompanyId == companyId).FirstOrDefaultAsync();
        var response = _mapper.Map<GetBankQueryResponse>(bank);
        return response;
    }

    public async Task<Bank> GetByIdAsync(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetById(id);
    }

    public async Task<Bank> RemoveByIdHard(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Bank bank = await _queryRepository.GetById(id);
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
        return bank;
    }

    public async Task<Bank> RemoveByIdSoft(string companyId, Bank bank)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(bank);
        await _unitOfWork.SaveChangesAsync();

        return bank;
    }

    public async Task<Bank> UpdateAsync(UpdateBankCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Bank newBank = _mapper.Map<Bank>(request);
        newBank.UpdateDate = DateTime.Now;
        _commandRepository.Update(newBank);
        await _unitOfWork.SaveChangesAsync();

        return newBank;
    }

    public async Task<PaginationResult<Bank>> GetAllActive(string companyId, int PageNumber, int PageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false && p.CompanyId == companyId).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(PageNumber, PageSize);

        return result;
    }

    public async Task<Bank> ChangeState(string companyId, Bank bank)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(bank);
        await _unitOfWork.SaveChangesAsync();

        return bank;
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }
}
