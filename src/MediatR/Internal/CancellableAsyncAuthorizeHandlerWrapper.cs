using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Internal
{
    internal abstract class CancellableAsyncAuthorizeHandlerWrapper<TResult>
    {
        public abstract Task Handle(ICancellableAsyncRequest<TResult> message, CancellationToken cancellationToken);
    }

    internal class CancellableAsyncAuthorizeHandlerWrapper<TCommand, TResult> : CancellableAsyncAuthorizeHandlerWrapper<TResult>
        where TCommand : ICancellableAsyncRequest<TResult>
    {
        private readonly ICancellableAsyncAuthorizeHandler<TCommand, TResult> _inner;

        public CancellableAsyncAuthorizeHandlerWrapper(ICancellableAsyncAuthorizeHandler<TCommand, TResult> inner)
        {
            _inner = inner;
        }

        public override async Task Handle(ICancellableAsyncRequest<TResult> message, CancellationToken cancellationToken)
        {
            await _inner.Handle((TCommand)message, cancellationToken);
        }
    }
}