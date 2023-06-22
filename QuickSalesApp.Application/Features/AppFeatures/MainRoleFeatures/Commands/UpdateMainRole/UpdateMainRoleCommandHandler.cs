
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;

public sealed class UpdateMainRoleCommandHandler : ICommandHandler<UpdateMainRoleCommand, UpdateMainRoleCommandResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public UpdateMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<UpdateMainRoleCommandResponse> Handle(UpdateMainRoleCommand request, CancellationToken cancellationToken)
    {
        MainRole mainRole = await _mainRoleService.GetByIdAsync(request.Id);
        if (mainRole == null) throw new Exception("Bu Rol Bulunamadı");
        if (mainRole.Title == request.Title) throw new Exception("Güncellemeye çalıştığınız Rol Adı eski adıyla aynıdır");

        if (mainRole.Title != request.Title)
        {
            MainRole checkMainRoleTitle = await _mainRoleService.GetByTitleAndCompanyId(request.Title,mainRole.CompanyId,cancellationToken);

            if (checkMainRoleTitle != null) throw new Exception("Bu Rol adı daha önce kullanılmış");


        }
        mainRole.Title= request.Title;
        await _mainRoleService.UpdateAsync(mainRole);
        return new();

        
    }
}
