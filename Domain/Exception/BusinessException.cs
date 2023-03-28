using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Domain.Exception
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class BusinessException : IOException
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, IOException innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
