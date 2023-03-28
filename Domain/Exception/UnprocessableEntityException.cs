using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Domain.Exception
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class UnprocessableEntityException : BusinessException
    {
        public UnprocessableEntityException()
        {
        }

        public UnprocessableEntityException(string message) : base(message)
        {
        }

        public UnprocessableEntityException(string message, IOException innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected UnprocessableEntityException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
