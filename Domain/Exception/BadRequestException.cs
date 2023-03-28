using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Domain.Exception
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class BadRequestException : BusinessException
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, IOException innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected BadRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
