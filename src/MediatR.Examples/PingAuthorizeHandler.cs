using System;
using System.IO;

namespace MediatR.Examples
{
    public class PingAuthorizeHandler : IAuthorizeHandler<Ping, Pong>
    {
        private readonly TextWriter _textWriter;

        public PingAuthorizeHandler(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void Handle(Ping message)
        {
            _textWriter.WriteLine("Authorize: Ping");
        }
    }
}