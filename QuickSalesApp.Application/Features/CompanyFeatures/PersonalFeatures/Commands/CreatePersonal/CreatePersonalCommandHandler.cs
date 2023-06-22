using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.CreatePersonal;

public sealed class CreatePersonalCommandHandler : ICommandHandler<CreatePersonalCommand, CreatePersonalCommandResponse>
{
    private readonly IPersonalService _personalService;

    public CreatePersonalCommandHandler(IPersonalService personalService)
    {
        _personalService = personalService;
    }

    public async Task<CreatePersonalCommandResponse> Handle(CreatePersonalCommand request, CancellationToken cancellationToken)
    {
        Personal personal = await _personalService.GetByEmailAsync(request.Email, request.CompanyId);
        if (personal != null) throw new Exception("Eklemek istediğiniz personel zaten kayıtlı");

        await _personalService.CreateAsync(request, cancellationToken);
        return new();
    }
}
