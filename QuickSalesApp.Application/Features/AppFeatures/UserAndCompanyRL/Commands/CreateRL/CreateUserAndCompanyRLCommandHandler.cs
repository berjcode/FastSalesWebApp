
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Features.AppFeatures.UserAndCompanyRL.Commands.CreateRL;

public sealed class CreateUserAndCompanyRLCommandHandler : ICommandHandler<CreateUserAndCompanyRLCommand, CreateUserAndCompanyRLCommandResponse>
{
    private readonly IUserAndCompanyRelationshipService _companyService;

    public CreateUserAndCompanyRLCommandHandler(IUserAndCompanyRelationshipService companyService)
    {
        _companyService = companyService;
    }

    public async Task<CreateUserAndCompanyRLCommandResponse> Handle(CreateUserAndCompanyRLCommand request, CancellationToken cancellationToken)
    {
        UserAndCompanyRelationship entity = await _companyService.GetByUSerIdAndCompanyId(request.AppUserId,request.CompanyId,cancellationToken);
        if (entity != null) throw new Exception("Bu kullanıcı daha önce bu şirkete kayıt edilmiş.");


        UserAndCompanyRelationship userAndCompanyRelationship = new(
            Guid.NewGuid().ToString(),
            request.AppUserId,
            request.CompanyId
            );

        await _companyService.Create(userAndCompanyRelationship, cancellationToken);
        return new();
    }
}
