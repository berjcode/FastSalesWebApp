using Microsoft.AspNetCore.Identity;
using QuickSalesApp.Application.Abstractions;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.AppEntities.Identity;
using QuickSalesApp.Domain.Dtos;

namespace QuickSalesApp.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<UserCommand, LoginCommandResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;
        public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager, IAuthService authService)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _authService.GetByEmailOrUserNameAsync(request.EmailAndUserName);

            if (user == null) throw new Exception("Kullanıcı bulunamadı!");

            var checkUser = await _authService.CheckPasswordAsync(user, request.Password);
            if (!checkUser) throw new Exception("Şifreniz yanlış!");

            IList<UserAndCompanyRelationship> companies = await _authService.GetCompanyListByUserIdAsync(user.Id);
            IList<CompanyDto> companiesDto = companies.Select(s => new CompanyDto(
                s.Company.Id, s.Company.Name)).ToList();

            if (companies.Count() == 0) throw new Exception("Herhangi bir şikete kayıtlı değilsiniz!");

            LoginCommandResponse response = new(
                Token: await _jwtProvider.CreateTokenAsync(user),
                Email: user.Email,
                UserId: user.Id,
                Name: user.Name,
                SurName: user.SurName,
                Companies: companiesDto,
                Company: companiesDto[0]

                );

            return response;
        }
    }
}
