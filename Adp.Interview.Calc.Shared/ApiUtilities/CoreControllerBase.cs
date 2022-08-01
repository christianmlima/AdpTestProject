using MediatR;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public abstract class CoreControllerBase
    {
        protected CoreControllerBase(IMediator mediator) => Mediator = mediator;
        protected IMediator Mediator { get; private set; }
    }
}
