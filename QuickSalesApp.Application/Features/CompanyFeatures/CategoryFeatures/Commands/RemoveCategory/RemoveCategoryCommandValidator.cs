﻿using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.RemoveCategory;

public class RemoveCategoryCommandValidator :AbstractValidator<RemoveCategoryCommand>
{
	public RemoveCategoryCommandValidator()
	{
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
