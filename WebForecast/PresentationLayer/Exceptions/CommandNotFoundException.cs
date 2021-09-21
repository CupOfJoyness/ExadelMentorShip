using System;
using System.Runtime.Serialization;

namespace PresentationLayer.Exceptions
{
    [Serializable]
    public class CommandNotFoundException : Exception
    {
        private const string CommandNotFoundMessage = "Wrong Input." ;

        public CommandNotFoundException() : base(CommandNotFoundMessage) { }
        protected CommandNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}