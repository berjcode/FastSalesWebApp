using AutoMapper;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetCustomerTransaction
{
    public sealed class GetCustomerTransactionQueryHandler : IQueryHandler<GetCustomerTransactionQuery, GetCustomerTransactionQueryResponse>
    {
        private readonly ICustomerTransactionService _customerTransactionService;


        public GetCustomerTransactionQueryHandler(ICustomerTransactionService customerTransactionService)
        {

            _customerTransactionService = customerTransactionService;

        }
        public async Task<GetCustomerTransactionQueryResponse> Handle(GetCustomerTransactionQuery request, CancellationToken cancellationToken)
        {
            var result = await _customerTransactionService.GetCustomerTransaction(request.companyId, request.CustomerTransactionId);

            return result;
        }
    }
}
