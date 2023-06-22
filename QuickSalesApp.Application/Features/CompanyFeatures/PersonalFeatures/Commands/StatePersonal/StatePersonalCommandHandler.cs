using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.StatePersonal
{
    public sealed class StatePersonalCommandHandler : ICommandHandler<StatePersonalCommand, StatePersonalCommandResponse>
    {
        private readonly IPersonalService _personalService;

        public StatePersonalCommandHandler(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        public async Task<StatePersonalCommandResponse> Handle(StatePersonalCommand request, CancellationToken cancellationToken)
        {
            Personal personal = await _personalService.GetByIdAsync(request.Id,request.CompanyId);
            if (personal == null) throw new Exception(ExceptionMessage.NullDataException);

            personal.IsActive = request.IsActive;
            personal.DeleterName = request.DeleterName;
            personal.DeletedTime = DateTime.Now;

            await _personalService.ChangeState(personal,request.CompanyId);
            return new();
        }
    }
}
