#region using
using AutoMapper;
using QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.CreateBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.UpdateBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetAllBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankBankAccountFeatures.Commands.CreateBankBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankBankAccountFeatures.Commands.UpdateBankBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankBankAccountFeatures.Queries.GetAllBankBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankBankAccountFeatures.Queries.GetBankBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.CreateBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.UpdateBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetAllBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.CreateBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.UpdateBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetAllBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.UpdateCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllFilterCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.CreateCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.UpdateCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllFilterCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.CreateCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.UpdateCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetAllFilterCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.CreateCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.UpdateCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllActiveCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.CreateDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.UpdateDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetAllDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.CreatePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.UpdatePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetAll;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetById;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.CreateProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.UpdateProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllBasketProductbyBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetByIdProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.UpdateProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByIdProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.CreateProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.UpdateProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetByIdProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.CreateProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.UpdateProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetAllProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetByIdProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.CreateProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.UpdateProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetByIdProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.CreateSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.UpdateSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetByIdSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.CreateSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.UpdateSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.CreateTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.UpdateTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetAllTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.CreateUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.UpdateUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllActiveUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllFilterUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetBasketUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.CreateVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.UpdateVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllActiveVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllFilterVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetVatType;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.AppEntities.Identity;
using QuickSalesApp.Domain.Dtos;
using QuickSalesApp.Domain.Dtos.SalesBasketDtoClient;
#endregion

namespace QuickSalesApp.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommand, Company>().ReverseMap();
            //Product
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
            CreateMap<CreateRoleCommand, AppRole>().ReverseMap();
            CreateMap<GetByIdProductQueryResponse, Product>().ReverseMap();
            //Department
            CreateMap<CreateDepartmentCommand, Department>().ReverseMap();
            CreateMap<Department, GetAllDepartmentQueryResponse>().ReverseMap();
            CreateMap<Department, GetDepartmentQueryResponse>().ReverseMap();
            CreateMap<UpdateDepartmentCommand, Department>().ReverseMap();



            //Personal
            CreateMap<CreatePersonalCommand, Personal>().ReverseMap();
            CreateMap<UpdatePersonalCommand, Personal>().ReverseMap();
            CreateMap<GetAllPersonalQueryResponse, Personal>().ReverseMap();
            CreateMap<GetByIdPersonalQueryResponse, Personal>().ReverseMap();

            //ProductBarcode
            CreateMap<CreateProductBarcodeCommand, ProductBarcode>().ReverseMap();
            CreateMap<UpdateProductBarcodeCommand, ProductBarcode>().ReverseMap();
            CreateMap<GetByIdProductBarcodeQueryResponse, ProductBarcode>().ReverseMap();
            CreateMap<GetAllBasketProductbyBarcodeQueryResponse, ProductBarcode>().ReverseMap();

          

            //Category
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<GetCategoryQueryResponse, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
            CreateMap<GetAllFilterCategoryQueryResponse, Category>().ReverseMap();


            //Currency
            CreateMap<CreateCurrencyCommand, Currency>().ReverseMap();
            CreateMap<GetCurrencyQueryResponse, Currency>().ReverseMap();
            CreateMap<UpdateCurrencyCommand, Currency>().ReverseMap();




            //product transaction
            CreateMap<CreateProductTransactionCommand, ProductTransaction>().ReverseMap();
            CreateMap<UpdateProductTransactionCommand, ProductTransaction>().ReverseMap();
            CreateMap<GetByIdProductTransactionQueryResponse, ProductTransaction>().ReverseMap();

            // product type 
            CreateMap<GetAllProductTypeQueryResponse, ProductType>().ReverseMap();
            CreateMap<CreateProductTypeCommand, ProductType>().ReverseMap();
            CreateMap<UpdateProductTypeCommand, ProductType>().ReverseMap();
            CreateMap<GetByIdProductTypeQueryResponse, ProductType>().ReverseMap();

            //Bank
            CreateMap<GetAllBankQueryResponse, Bank>().ReverseMap();
            CreateMap<GetBankQueryResponse, Bank>().ReverseMap();
            CreateMap<CreateBankCommand, Bank>().ReverseMap();
            CreateMap<UpdateBankCommand, Bank>().ReverseMap();
            //BankTransaction
            CreateMap<GetAllBankTransactionQueryResponse, BankTransaction>().ReverseMap();
            CreateMap<GetBankTransactionQueryResponse, BankTransaction>().ReverseMap();
            CreateMap<CreateBankTransactionCommand, BankTransaction>().ReverseMap();
            CreateMap<UpdateBankTransactionCommand, BankTransaction>().ReverseMap();

            // product unit
            CreateMap<CreateProductUnitCommand, ProductUnit>().ReverseMap();
            CreateMap<UpdateProductUnitCommand, ProductUnit>().ReverseMap();
            CreateMap<GetByIdProductUnitQueryResponse, ProductUnit>().ReverseMap();


            //CustomerType
            CreateMap<GetAllCustomerTypeQueryResponse, CustomerType>().ReverseMap();
            CreateMap<GetCustomerTypeQueryResponse, CustomerType>().ReverseMap();
            CreateMap<CreateCustomerTypeCommand, CustomerType>().ReverseMap();
            CreateMap<UpdateCustomerTypeCommand, CustomerType>().ReverseMap(); 
            CreateMap<GetAllActiveCustomerTypeQuery, CustomerType>().ReverseMap();
            CreateMap<CustomerTypeDto, CustomerType>().ReverseMap();
            //Customer
            CreateMap<CreateCustomerCommand, Customer>().ReverseMap();
            CreateMap<GetAllCustomerQueryResponse, Customer>().ReverseMap();
            CreateMap<GetCustomerQueryResponse, Customer>().ReverseMap();
            CreateMap<UpdateCustomerCommand, Customer>().ReverseMap();
            CreateMap<GetAllFilterCustomerQueryResponse, Customer>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();

            //Customer Transaction
            CreateMap<CreateCustomerTransactionCommand, CustomerTransaction>().ReverseMap();
            CreateMap<GetAllFilterCustomerTransactionQueryResponse, CustomerTransaction>().ReverseMap();
            CreateMap<GetCustomerTransactionQueryResponse, CustomerTransaction>().ReverseMap();
            CreateMap<UpdateCustomerTransactionCommand, CustomerTransaction>().ReverseMap();
            // safe 
            CreateMap<CreateSafeCommand, Safe>().ReverseMap();
            CreateMap<GetByIdSafeQueryResponse, Safe>().ReverseMap();
            CreateMap<UpdateSafeCommand, Safe>().ReverseMap();

            // vatType
            CreateMap<CreateVatTypeCommand, VatType>().ReverseMap();
            CreateMap<UpdateVatTypeCommand, VatType>().ReverseMap();
            CreateMap<GetVatTypeQueryResponse, VatType>().ReverseMap();
            CreateMap<GetAllVatTypeQueryResponse, VatType>().ReverseMap();
            CreateMap<GetAllActiveVatTypeQueryResponse, VatType>().ReverseMap();
            CreateMap<GetAllFilterVatTypeQueryResponse, VatType>().ReverseMap();

            //unit 
            CreateMap<GetAllUnitQueryResponse, Unit>().ReverseMap();
            CreateMap<CreateUnitCommand, Unit>().ReverseMap();
            CreateMap<GetUnitQueryResponse, Unit>().ReverseMap();
            CreateMap<UpdateUnitCommand, Unit>().ReverseMap();
            CreateMap<GetAllActiveUnitQueryResponse, Unit>().ReverseMap();
            CreateMap<GetAllFilterUnitQueryResponse, Unit>().ReverseMap();
            CreateMap<GetBasketUnitQueryResponse, Unit>().ReverseMap();
            CreateMap<UnitListDto,Unit >().ReverseMap();
            


            // transaction type 
            CreateMap<GetAllTransactionTypeQueryResponse, TransactionType>().ReverseMap();
            CreateMap<CreateTransactionTypeCommand, TransactionType>().ReverseMap();
            CreateMap<GetTransactionTypeQueryResponse, TransactionType>().ReverseMap();
            CreateMap<UpdateTransactionTypeCommand, TransactionType>().ReverseMap();

            // safe transaction
            CreateMap<CreateSafeTransactionCommand, SafeTransaction>().ReverseMap();
            CreateMap<UpdateSafeTransactionCommand, SafeTransaction>().ReverseMap();
            CreateMap<GetSafeTransactionQueryResponse, SafeTransaction>().ReverseMap();
            //BankAccount

            CreateMap<CreateBankAccountCommand, BankAccount>().ReverseMap();
            CreateMap<UpdateBankAccountCommand, BankAccount>().ReverseMap();
            CreateMap<GetBankAccountQueryResponse, BankAccount>().ReverseMap();
            CreateMap<GetAllBankAccountQueryResponse, BankAccount>().ReverseMap();
            //BankBankAccount
            CreateMap<CreateBankBankAccountCommand, BankBankAccount>().ReverseMap();
            CreateMap<UpdateBankBankAccountCommand, BankBankAccount>().ReverseMap();
            CreateMap<GetBankBankAccountQueryResponse, BankBankAccount>().ReverseMap();
            CreateMap<GetAllBankBankAccountQueryResponse, BankBankAccount>().ReverseMap();
        }

    }
}
