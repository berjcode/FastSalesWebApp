using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.Repositories.App.CompanyRepositories;
using QuickSalesApp.Domain.Repositories.App.MainRoleAndRoleRepositories;
using QuickSalesApp.Domain.Repositories.App.MainRoleAndUserRepositories;
using QuickSalesApp.Domain.Repositories.App.MainRoleRepositories;
using QuickSalesApp.Domain.Repositories.App.UserAndCompanyRepositories;
using QuickSalesApp.Domain.Repositories.Company.BankAccountRepositories;
using QuickSalesApp.Domain.Repositories.Company.BankBankAccountRepositories;
using QuickSalesApp.Domain.Repositories.Company.BankRepositories;
using QuickSalesApp.Domain.Repositories.Company.BankTransactionRepositories;
using QuickSalesApp.Domain.Repositories.Company.CategoryRepositories;
using QuickSalesApp.Domain.Repositories.Company.CurrencyRepositories;
using QuickSalesApp.Domain.Repositories.Company.CustomerRepositories;
using QuickSalesApp.Domain.Repositories.Company.CustomerTransactionRepositories;
using QuickSalesApp.Domain.Repositories.Company.CustomerTypeRepositories;
using QuickSalesApp.Domain.Repositories.Company.DepartmentRepositories;
using QuickSalesApp.Domain.Repositories.Company.PersonalRepositories;
using QuickSalesApp.Domain.Repositories.Company.ProductBarcodeRepositories;
using QuickSalesApp.Domain.Repositories.Company.ProductPriceRepositories;
using QuickSalesApp.Domain.Repositories.Company.ProductRepositories;
using QuickSalesApp.Domain.Repositories.Company.ProductTransactionRepositories;
using QuickSalesApp.Domain.Repositories.Company.ProductTypeRepositories;
using QuickSalesApp.Domain.Repositories.Company.ProductUnitRepositories;
using QuickSalesApp.Domain.Repositories.Company.SafeRepositories;
using QuickSalesApp.Domain.Repositories.Company.SafeTransactionRepositories;
using QuickSalesApp.Domain.Repositories.Company.TransactionTypeRepositories;
using QuickSalesApp.Domain.Repositories.Company.UnitRepositories;
using QuickSalesApp.Domain.Repositories.Company.VatTypeRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Repositories.AppDbRepositories.CompanyRepositories;
using QuickSalesApp.Persistance.Repositories.AppDbRepositories.MainRoleAndRoleRepositories;
using QuickSalesApp.Persistance.Repositories.AppDbRepositories.MainRoleAndUserRepositories;
using QuickSalesApp.Persistance.Repositories.AppDbRepositories.MainRoleRepositories;
using QuickSalesApp.Persistance.Repositories.AppDbRepositories.UserAndCompanyRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.BankAccountRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.BankBankAccountRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.BankRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.BankTransactionRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.CategoryRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.CurrencyRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.CustomerRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.CustomerTransactionRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.CustomerTypeRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.DepartmentRepository;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.PersonalRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.ProductBarcodeRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.ProductPriceRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.ProductRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.ProductTransactionRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.ProductTypeRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.ProductUnitRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.SafeRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.SafeTransactionRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.TransactionTypeRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.UnitRepositories;
using QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.VatTypeRepositories;
using QuickSalesApp.Persistance.Services.AppServices;
using QuickSalesApp.Persistance.Services.CompanyServices;
using QuickSalesApp.Persistance.UnitOfWork;

namespace QuickSalesApp.WebApi.Configurations;

public class PersistanceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {

        #region Context UnitOfWork ApplicationService
        services.AddScoped<ICompanyDbUnitOfWork, CompanyDbUnitOfWork>();
        services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

        services.AddScoped<IContextService, QuickSalesApp.Persistance.ContextService>();

        #endregion

        #region Repository 

        //App
        //Company
        services.AddScoped<ICompanyDbQueryRepository, CompanyCommandRepository>();
        services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
        //MainRole
        services.AddScoped<IMainRoleCommadRepository, MainRoleCommandRepository>();
        services.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
        services.AddScoped<IMainRoleAndRoleComandRepository, MainRoleAndRoleCommandRepository>();
        services.AddScoped<IMainRoleAndRoleQueryRepositories, MainRoleAndRoleQueryRepository>();
        services.AddScoped<IMainRoleAndUserCommandRepository, MainRoleAndUserCommandRepository>();
        services.AddScoped<IMainRoleAndUserQueryRepository, MainRoleAndUserQueryRepository>();
        //UserAndCompany
        services.AddScoped<IUserAndCompanyCommandRepository, UserAndCompanyCommandRepository>();
        services.AddScoped<IUserAndCompanyQueryRepository, UserAndCompanyQueryRepository>();






        #endregion

        #region CompanyDbContext
        services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
        services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
        //Department
        services.AddScoped<IDepartmentQueryRepository, DepartmentQueryRepository>();
        services.AddScoped<IDepartmentCommandRepository, DepartmentCommandRepository>();
        //Personal
        services.AddScoped<IPersonalCommandRepository, PersonalCommandRepository>();
        services.AddScoped<IPersonalQueryRepository, PersonalQueryRepository>();

        //CustomerType
        services.AddScoped<ICustomerTypeCommandRepository, CustomerTypeCommandRepository>();
        services.AddScoped<ICustomerTypeQueryRepository, CustomerTypeQueryRepository>();
        //CustomerTransaction
        services.AddScoped<ICustomerTransactionCommandRepository, CustomerTransactionCommandRepository>();
        services.AddScoped<ICustomerTransactionQueryRepository, CustomerTransactionQueryRepository>();
        //BankBankAccount
        services.AddScoped<IBankBankAccountCommandRepository, BankBankAccountCommandRepository>();
        services.AddScoped<IBankBankAccountQueryRepository, BankBankAccountQueryRepository>();
        //Bank
        services.AddScoped<IBankCommandRepository, BankCommandRepository>();
        services.AddScoped<IBankQueryRepository, BankQueryRepository>();
        //BankAccount
        services.AddScoped<IBankAccountCommandRepository, BankAccountCommandRepository>();
        services.AddScoped<IBankAccountQueryRepository, BankAccountQueryRepository>();
        //BankTransaction
        services.AddScoped<IBankTransactionCommandRepository, BankTransactionCommandRepository>();
        services.AddScoped<IBankTransactionQueryRepository, BankTransactionQueryRepository>();
        //Category
        services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
        //Currency
        services.AddScoped<ICurrencyCommandRepository, CurrencyCommandRepository>();
        services.AddScoped<ICurrencyQueryRepository, CurrencyQueryRepository>();
        //Customer
        services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
        services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
        //ProductBarcode
        services.AddScoped<IProductBarcodeCommandRepository, ProductBarcodeCommandRepository>();
        services.AddScoped<IProductBarcodeQueryRepository, ProductBarcodeQueryRepository>();
      
        
        //ProductTransaction
        services.AddScoped<IProductTransactionCommandRepository, ProductTransactionCommandRepository>();
        services.AddScoped<IProductTransactionQueryRepository, ProductTransactionQueryRepository>();
        //ProductType
        services.AddScoped<IProductTypeCommandRepository, ProductTypeCommandRepository>();
        services.AddScoped<IProductTypeQueryRepository, ProductTypeQueryRepository>();
        //ProductUnit
        services.AddScoped<IProductUnitCommandRepository, ProductUnitCommandRepository>();
        services.AddScoped<IProductUnitQueryRepository, ProductUnitQueryRepository>();
        //Safe
        services.AddScoped<ISafeCommandRepository, SafeCommandRepository>();
        services.AddScoped<ISafeQueryRepository, SafeQueryRepository>();
        //SafeTransaction
        services.AddScoped<ISafeTransactionCommandRepository, SafeTransactionCommandRepository>();
        services.AddScoped<ISafeTransactionQueryRepository, SafeTransactionQueryRepository>();
        //TransactionType
        services.AddScoped<ITransactionTypeCommandRepository, TransactionTypeCommandRepository>();
        services.AddScoped<ITransactionTypeQueryRepository, TransactionTypeQueryRepository>();
        //Unit
        services.AddScoped<IUnitCommandRepository, UnitCommandRepository>();
        services.AddScoped<IUnitQueryRepository, UnitQueryRepository>();
        //VatType
        services.AddScoped<IVatTypeCommandRepository, VatTypeCommandRepository>();
        services.AddScoped<IVatTypeQueryRepository, VatTypeQueryRepository>();
        #endregion


        #region ServicesApp
        //Auth
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IUserService, UserService>();
        //MainRole
        services.AddScoped<IMainRoleService, MainRoleService>();
        services.AddScoped<IMainRoleAndRoleRelationshipService, MainRoleAndRoleRelationshipService>();
        services.AddScoped<IMainRoleAndUserRelationshipService, MainRoleAndUserRelationshipService>();
        services.AddScoped<IUserAndCompanyRelationshipService, UserAndCompanyRelationshipService>();

        #endregion
        #region ServicesCompany


        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IRoleService, RoleService>();
        //Department
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IPersonalService, PersonalService>();

        services.AddScoped<IBankService, BankService>();
        services.AddScoped<IBankAccountService, BankAccountService>();
        services.AddScoped<IBankBankAccountService, BankBankAccountService>();
        services.AddScoped<IBankTransactionService, BankTransactionService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerTransactionService, CustomerTransactionService>();
        services.AddScoped<ICustomerTypeService, CustomerTypeService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductBarcodeService, ProductBarcodeService>();
       
        services.AddScoped<IProductTransactionService, ProductTransactionService>();
        services.AddScoped<IProductTypeService, ProductTypeService>();
        services.AddScoped<IProductUnitService, ProductUnitService>();
        services.AddScoped<ISafeService, SafeService>();
        services.AddScoped<ISafeTransactionService, SafeTransactionService>();
        services.AddScoped<ITransactionTypeService, TransactionTypeService>();
        services.AddScoped<IUnitService, UnitService>();
        services.AddScoped<IVatTypeService, VatTypeService>();

        #endregion



    }
}
