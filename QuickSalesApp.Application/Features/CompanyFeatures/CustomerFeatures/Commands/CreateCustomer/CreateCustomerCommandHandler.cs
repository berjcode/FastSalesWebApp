using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;

public sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
{
    private readonly ICustomerService _customerService;

    public CreateCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        List<int> numbers = new List<int> { request.SPECode1, request.SPECode2, request.SPECode3, request.SPECode4, request.SPECode5 };
        numbers.RemoveAll(n => n == 0);

        if (numbers.Count != numbers.Distinct().Count()) throw new Exception("Filtreleme Kodları Aynı Olamaz");
        await _customerService.CreateAsync(request, cancellationToken);
        return new();
    }
}
