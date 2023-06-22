using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllFilterCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllGroupCodes;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetLastCode;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.CustomerRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Migrations.CompanyDb;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class CustomerService : ICustomerService
{
    private readonly ICustomerCommandRepository _commandRepository;
    private readonly ICustomerQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public CustomerService(
        ICustomerCommandRepository commandRepository,
        ICustomerQueryRepository queryRepository, IContextService contextService,
        ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<PaginationResult<Customer>> GetAllFilter(GetAllFilterCustomerQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        if (request.search != null)
        {
            var queryGetAllSearch = _queryRepository.GetAll().Where(p => p.CompanyId == request.CompanyId && p.IsDelete == false && p.Name.Contains(request.search))
           .Include(p => p.CustomerType);
            var resultGetAllSearch = await queryGetAllSearch.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAllSearch;
        }
        if (request.Expression == null)
        {
            var queryGetAll = _queryRepository.GetAll().Where(p => p.CompanyId == request.CompanyId && p.IsDelete == false)
           .Include(p => p.CustomerType);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }

        var query = _queryRepository.GetAll().Where(p => p.CompanyId == request.CompanyId && p.IsDelete == false)
            .Where(request.Expression).Include(p => p.CustomerType);
        var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;

    }
    public async Task<Customer> ChangeState(string companyId, Customer customer)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        _commandRepository.Update(customer);
        await _unitOfWork.SaveChangesAsync();
        return customer;
    }

    public async Task CreateAsync(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Customer customer = _mapper.Map<Customer>(request);
        customer.Code = await generateCode(request.Code.ToUpper(), request.companyId);
        await _commandRepository.AddAsync(customer, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Customer>> GetAllActive(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false && p.CompanyId == companyId).Include(p => p.CustomerType).ToListAsync();

        return result;
    }
    public async Task<PaginationResult<Customer>> GetAll(string companyId, int pageNumber, int pageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsDelete == false && p.CompanyId == companyId).Include(p => p.CustomerType).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(pageNumber, pageSize);
        return result;
    }

    public async Task<Customer> GetByIdAsync(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetById(id);
    }

    public async Task<Customer> GetByNameAsync(string companyId, string name)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.Name == name);
    }
    public async Task<GetCustomerQueryResponse> GetCustomer(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var customer = await _queryRepository.GetWhere(x => x.Id == id && x.CompanyId == companyId).Include(x => x.CustomerType).FirstOrDefaultAsync();
        var response = _mapper.Map<GetCustomerQueryResponse>(customer);
        return response;
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public int GetCountbyFilter(string companyId, string expression, string search)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        if (expression == null)
            return _queryRepository.GetAll().Count();
        if (search == null && expression != null)
            return _queryRepository.GetAll().Where(expression).Count();

        return _queryRepository.GetAll().Where(x => x.Name == search).Count();
    }

    public async Task<Customer> RemoveByIdHard(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Customer customer = await _queryRepository.GetById(id);
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> RemoveByIdSoft(string companyId, Customer customer)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        _commandRepository.Update(customer);
        await _unitOfWork.SaveChangesAsync();

        return customer;
    }

    public async Task<Customer> UpdateAsync(UpdateCustomerCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Customer newCustomer = _mapper.Map<Customer>(request);
        newCustomer.UpdateDate = DateTime.Now;
        _commandRepository.Update(newCustomer);
        await _unitOfWork.SaveChangesAsync();

        return newCustomer;
    }

    public async Task<GetAllGroupCodesQueryResponse> GetGroupCodes(GetAllGroupCodesQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);

        var result = _queryRepository.GetAll()
        .Select(x => x.GroupCode)
        .Distinct()
        .ToList();

        return new(result);
    }
    public string GetLastCode(GetLastCodeQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);

        var result = _queryRepository.GetAll();
        var lastItem = result.OrderBy(p => p.Id).Last();

        Match match = Regex.Match(lastItem.Code, @"\d+");


        if (match.Success)
        {
            // Bulunan sayıyı tam sayıya dönüştürüyoruz
            int number = int.Parse(match.Value);

            // Sayıyı bir artırıyoruz
            number++;

            // Yeni sayıyı stringe dönüştürerek dizedeki sayıyı değiştiriyoruz
            string replacedString = lastItem.Code.Replace(match.Value, number.ToString("D3"));

            return replacedString;
        }
        return "";
    }
    private async Task<string> generateCode(string code, string companyId)
    {
        var stockNumber = await getByCode(code, companyId) + 1;
        return $"{code}{stockNumber.ToString("D3")}";
    }
    private async Task<int> getByCode(string code, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var data = _queryRepository.GetWhere(p => p.Code.Substring(0, code.Length) == code);
        return data.Count();
    }
}
