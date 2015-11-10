using System.IO;

namespace MediatR.Examples
{
    using System;
    using System.Threading.Tasks;

    public class PingAsyncAuthorizeHandler : IAsyncAuthorizeHandler<PingAsync, Pong>
    {
        private readonly TextWriter _textWriter;

        public PingAsyncAuthorizeHandler(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public async Task Handle(PingAsync message)
        {
            await Task.Factory.StartNew(() => _textWriter.WriteLine("Async Authorize: PingAsync"));
        }
    }
}