
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;

namespace QuickSalesApp.Application.Features.AppFeatures.UserAndCompanyRL.Commands.RemoveByIdRL;

public sealed class RemoveByIdUserAndCompanyRLCommandHandler : ICommandHandler<RemoveByIdUserAndCompanyRLCommand, RemoveByIdUserAndCompanyRLCommandResponse>
{
    private readonly IUserAndCompanyRelationshipService _service;

    public RemoveByIdUserAndCompanyRLCommandHandler(IUserAndCompanyRelationshipService service)
    {
        _service = service;
    }

    public async Task<RemoveByIdUserAndCompanyRLCommandResponse> Handle(RemoveByIdUserAndCompanyRLCommand request, CancellationToken cancellationToken)
    {
        await _service.RemoveByIdAsync(request.Id);
        return new();
    }
}
