using System.Threading.Tasks;

namespace MediatR.Internal
{
    internal abstract class AsyncAuthorizeHandlerWrapper<TResult>
    {
        public abstract Task Handle(IAsyncRequest<TResult> message);
    }

    internal class AsyncAuthorizeHandlerWrapper<TCommand, TResult> : AsyncAuthorizeHandlerWrapper<TResult>
        where TCommand : IAsyncRequest<TResult>
    {
        private readonly IAsyncAuthorizeHandler<TCommand, TResult> _inner;

        public AsyncAuthorizeHandlerWrapper(IAsyncAuthorizeHandler<TCommand, TResult> inner)
        {
            _inner = inner;
        }

        public override async Task Handle(IAsyncRequest<TResult> message)
        {
            await _inner.Handle((TCommand)message);
        }
    }
}