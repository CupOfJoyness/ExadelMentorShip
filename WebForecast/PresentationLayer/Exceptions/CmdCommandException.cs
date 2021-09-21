using System;
using System.Runtime.Serialization;

namespace PresentationLayer.Exceptions
{
    [Serializable]
    public class CmdCommandException : Exception
    {
        public CmdCommandException(string message) : base(message) { }
        protected CmdCommandException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}