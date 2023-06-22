using QuickSalesApp.Domain.Dtos;

namespace QuickSalesApp.Application.Features.AppFeatures.AuthFeatures.Commands.Login;

public sealed record LoginCommandResponse(
       TokenRefreshTokenDto Token,
       string Email,
       string UserId,
       string Name,
       string SurName,
       IList<CompanyDto> Companies,

       CompanyDto Company);
