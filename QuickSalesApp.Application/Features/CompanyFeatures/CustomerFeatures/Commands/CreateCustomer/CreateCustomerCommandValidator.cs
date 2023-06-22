using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;

public sealed class CreateCustomerCommandValidator :AbstractValidator<CreateCustomerCommand>
{
	public CreateCustomerCommandValidator()
	{
		RuleFor(x=> x.companyId).NotEmpty().WithMessage("CompanyId Boş olamaz.");
        RuleFor(x => x.companyId).NotNull().WithMessage("CompanyId Boş olamaz.");
        RuleFor(x => x.Code).NotEmpty().WithMessage("Code Boş olamaz.");
        RuleFor(x => x.Code).NotNull().WithMessage("Code Boş olamaz.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name Boş olamaz.");
        RuleFor(x => x.Name).NotNull().WithMessage("Name Boş olamaz.");
        //RuleFor(x => x.Address).NotEmpty().WithMessage("Address1 Boş olamaz.");
        //RuleFor(x => x.Address).NotNull().WithMessage("Address1 Boş olamaz.");
        RuleFor(x => x.CellPhone1).NotEmpty().WithMessage("Cep telefonu Boş olamaz.");
        //RuleFor(x => x.CellPhone2).NotNull().WithMessage("Cep telefonu  Boş olamaz.");
        
        //RuleFor(x => x.Address2).NotEmpty().WithMessage("Address2 Boş olamaz.");
        //RuleFor(x => x.Address2).NotNull().WithMessage("Address2 Boş olamaz.");
        //RuleFor(x => x.Telephone).NotEmpty().WithMessage("telefon Boş olamaz.");
        //RuleFor(x => x.Telephone).NotNull().WithMessage("telefon Boş olamaz.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email Boş olamaz.");
        RuleFor(x => x.Email).NotNull().WithMessage("Email Boş olamaz.");
        RuleFor(x => x.CustomerTypeId).NotEmpty().WithMessage("cari türü  Boş olamaz.");
        RuleFor(x => x.CustomerTypeId).NotNull().WithMessage("cari türü  Boş olamaz.");
    }
}
