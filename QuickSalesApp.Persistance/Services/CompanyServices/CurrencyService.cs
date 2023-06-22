using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.CreateCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.UpdateCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetCurrency;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.CurrencyRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class CurrencyService : ICurrencyService
{


    private readonly ICurrencyCommandRepository _currencyCommandRepository;
    private readonly ICurrencyQueryRepository _currencyQueryRepository;
    private readonly IContextService _contextService;
    private CompanyDbContext _context;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CurrencyService(ICurrencyCommandRepository currencyCommandRepository,
        ICurrencyQueryRepository currencyQueryRepository,
        IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
    {
        _currencyCommandRepository = currencyCommandRepository;
        _currencyQueryRepository = currencyQueryRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Currency> ChangeState(string companyId, Currency currency)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _currencyCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _currencyCommandRepository.Update(currency);
        await _unitOfWork.SaveChangesAsync();
        return currency;
    }

    public async Task CreateAsync(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _currencyCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Currency currency = _mapper.Map<Currency>(request);
        await _currencyCommandRepository.AddAsync(currency, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<Currency>> GetAllActive(string companyId, int pageNumber, int pageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _currencyQueryRepository.SetDbContextInstance(_context);
        var result = await _currencyQueryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(pageNumber, pageSize);
        return result;
    }

    public async Task<Currency> GetByIdAsync(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _currencyQueryRepository.SetDbContextInstance(_context);
        return await _currencyQueryRepository.GetById(id);
    }

    public async Task<Currency> GetByNameAsync(string companyId, string name)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _currencyQueryRepository.SetDbContextInstance(_context);

        return await _currencyQueryRepository.GetFirstByExpression(p => p.Name == name);
    }
    public async Task<GetCurrencyQueryResponse> GetCurrency(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _currencyQueryRepository.SetDbContextInstance(_context);

        var currency = await _currencyQueryRepository.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
        var response = _mapper.Map<GetCurrencyQueryResponse>(currency);

        return response;
    }
    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _currencyQueryRepository.SetDbContextInstance(_context);
        return _currencyQueryRepository.GetAll().Count();
    }

    public async Task<Currency> RemoveByIdHard(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _currencyCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Currency currency = await _currencyQueryRepository.GetById(id);
        await _currencyCommandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
        return currency;
    }

    public async Task<Currency> RemoveByIdSoft(string companyId, Currency currency)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _currencyCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        _currencyCommandRepository.Update(currency);
        await _unitOfWork.SaveChangesAsync();

        return currency;
    }

    public async Task<Currency> UpdateAsync(UpdateCurrencyCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _currencyCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Currency newCurrency = _mapper.Map<Currency>(request);
        _currencyCommandRepository.Update(newCurrency);
        await _unitOfWork.SaveChangesAsync();

        return newCurrency;
    }


}
