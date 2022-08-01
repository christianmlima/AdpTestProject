using MediatR;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public interface ICoreHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
    }
}
