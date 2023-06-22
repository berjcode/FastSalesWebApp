using MediatR;

namespace QuickSalesApp.Application.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
