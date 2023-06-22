using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.DeleteBank;

public sealed class DeleteBankCommandHandler : ICommandHandler<DeleteBankCommand, DeleteBankCommandResponse>
{
    private readonly IBankService _bankService;

    public DeleteBankCommandHandler(IBankService bankService)
    {
        _bankService = bankService;
    }

    public async Task<DeleteBankCommandResponse> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
    {
        Bank bank= await _bankService.GetByIdAsync(request.CompanyId, request.BankId);
        if (bank == null) throw new Exception("Bu bankId Bulunamadı");

        bank.IsDelete = request.IsDelete;
        bank.DeleterName = request.DeleterName;
        bank.DeletedTime = DateTime.Now;

        Bank newbank = await _bankService.RemoveByIdSoft(request.CompanyId, bank);
        return new();
    }
}
