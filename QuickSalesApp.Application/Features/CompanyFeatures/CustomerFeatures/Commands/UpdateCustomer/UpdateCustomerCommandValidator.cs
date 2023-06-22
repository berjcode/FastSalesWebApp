using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomer;

public sealed class UpdateCustomerCommandValidator:AbstractValidator<UpdateCustomerCommand>
{
	public UpdateCustomerCommandValidator()
	{
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id alanı boş olamaz!");
        RuleFor(p => p.Id).NotNull().WithMessage("Id alanı boş olamaz!");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name bilgisi boş olamaz!");
        RuleFor(p => p.Name).NotNull().WithMessage("Name bilgisi boş olamaz!");
        RuleFor(p => p.Code).NotEmpty().WithMessage("Kod bilgisi boş olamaz!");
        RuleFor(p => p.Code).NotNull().WithMessage("kod bilgisi boş olamaz!");
        RuleFor(p => p.Email).NotEmpty().WithMessage("mail bilgisi boş olamaz!");
        RuleFor(p => p.Email).NotNull().WithMessage("mail bilgisi boş olamaz!");
        RuleFor(p => p.CellPhone1).NotEmpty().WithMessage("Cep telefonu bilgisi boş olamaz!");
        //RuleFor(p => p.CellPhone2).NotNull().WithMessage("Cep telefonu  bilgisi boş olamaz!");
        //RuleFor(p => p.Telephone).NotEmpty().WithMessage("telefon bilgisi boş olamaz!");
        //RuleFor(p => p.Telephone).NotNull().WithMessage("telefon bilgisi boş olamaz!");

        RuleFor(p => p.CustomerTypeId).NotEmpty().WithMessage("cari türü bilgisi boş olamaz!");
        RuleFor(p => p.CustomerTypeId).NotNull().WithMessage("cari türü bilgisi boş olamaz!");

    }
}
