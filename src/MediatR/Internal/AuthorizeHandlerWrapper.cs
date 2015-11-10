namespace MediatR.Internal
{
    internal abstract class AuthorizeHandlerWrapper<TResult>
    {
        public abstract void Handle(IRequest<TResult> message);
    }

    internal class AuthorizeHandlerWrapper<TCommand, TResult> : AuthorizeHandlerWrapper<TResult>
        where TCommand : IRequest<TResult>
    {
        private readonly IAuthorizeHandler<TCommand, TResult> _inner;

        public AuthorizeHandlerWrapper(IAuthorizeHandler<TCommand, TResult> inner)
        {
            _inner = inner;
        }

        public override void Handle(IRequest<TResult> message)
        {
            _inner.Handle((TCommand)message);
        }
    }
}