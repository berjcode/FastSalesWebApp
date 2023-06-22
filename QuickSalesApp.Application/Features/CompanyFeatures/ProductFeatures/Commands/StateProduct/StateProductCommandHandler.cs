using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.StateProduct
{
    public sealed class StateProductCommandHandler : ICommandHandler<StateProductCommand, StateProductCommandResponse>
    {
        private readonly IProductService _productService;

        public StateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<StateProductCommandResponse> Handle(StateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productService.GetByIdAsync(request.Id,request.CompanyId);
            if (product == null) throw new Exception(ExceptionMessage.NullDataException);

            product.DeleterName = request.DeleterName;
            product.IsActive = request.IsActive;
            product.DeletedTime = DateTime.Now;

            await _productService.ChangeState(product, request.CompanyId);
            return new();
        }
    }
}
