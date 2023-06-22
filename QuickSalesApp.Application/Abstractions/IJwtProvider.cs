using QuickSalesApp.Domain.AppEntities.Identity;
using QuickSalesApp.Domain.Dtos;

namespace QuickSalesApp.Application.Abstractions;

public interface IJwtProvider
{
    Task<TokenRefreshTokenDto> CreateTokenAsync (AppUser user);
}
