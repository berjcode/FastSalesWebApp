using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.CompanyRepositories;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Services.AppServices;

public sealed class CompanyService : ICompanyService
{
    private static readonly Func<AppDbContext, string, Task<Company?>> GetCompanyByNameCompiled = EF.CompileAsyncQuery((AppDbContext context, string name)
        => context.Set<Company>().FirstOrDefault(p => p.Name == name));



    private readonly ICompanyDbQueryRepository _companyCommandRepository;
    private readonly ICompanyQueryRepository _companyQueryRepository;
    private readonly IAppUnitOfWork _appUnitOfWork;
    private readonly IMapper _mapper;

    public CompanyService(IMapper mapper, ICompanyDbQueryRepository companyCommandRepository, ICompanyQueryRepository companyQueryRepository, IAppUnitOfWork appUnitOfWork)
    {

        _mapper = mapper;
        _companyCommandRepository = companyCommandRepository;
        _companyQueryRepository = companyQueryRepository;
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company company = _mapper.Map<Company>(request);
        company.Id = Guid.NewGuid().ToString();
        company.UpdateDate = null;
        company.CreatedDate = DateTime.Now;
        await _companyCommandRepository.AddAsync(company, cancellationToken);
        await _appUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<Company> GetAll()
    {
        return _companyQueryRepository.GetAll();
    }

    public async Task<Company?> GetCompanyByName(string name,CancellationToken cancellationToken)
    {
        return await _companyQueryRepository.GetFirstByExpression(p => p.Name == name,cancellationToken);
    }

  
    public async Task MigrateCompanyDatabases()
    {
        var compaines = await _companyQueryRepository.GetAll().ToListAsync();

        foreach (var company in compaines)
        {
            var db = new CompanyDbContext(company);
            db.Database.Migrate();
        }
    }
}
