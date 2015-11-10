namespace MediatR
{
    /// <summary>
    /// Defines a Authorization handler for a request
    /// </summary>
    /// <typeparam name="TRequest">The type of request being handled</typeparam>
    public interface IAuthorizeHandler<in TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="message">The request message</param>
        void Handle(TRequest message);
    }
}