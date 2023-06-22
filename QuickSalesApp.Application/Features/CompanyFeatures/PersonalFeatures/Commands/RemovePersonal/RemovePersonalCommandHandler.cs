﻿using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.RemovePersonal;

public sealed class RemovePersonalCommandHandler : ICommandHandler<RemovePersonalCommand, RemovePersonalCommandResponse>
{
    private readonly IPersonalService _personalService;

    public RemovePersonalCommandHandler(IPersonalService personalService)
    {
        _personalService = personalService;
    }

    public async Task<RemovePersonalCommandResponse> Handle(RemovePersonalCommand request, CancellationToken cancellationToken)
    {
        Personal personal = await _personalService.GetByIdAsync(request.id, request.CompanyId);
        if (personal == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _personalService.RemoveByIdHard(request);
        return new();
    }
}
