using System;
using System.Runtime.Serialization;

namespace shop_backend.Services
{
    [Serializable]
    internal class EmailFailedToSendException : Exception
    {
        public EmailFailedToSendException()
        {
        }

        public EmailFailedToSendException(string message) : base(message)
        {
        }

        public EmailFailedToSendException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailFailedToSendException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}