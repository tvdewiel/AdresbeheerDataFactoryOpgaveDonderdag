using System.Runtime.Serialization;

namespace AdresbeheerDataLayerProvider
{
    [Serializable]
    internal class AdresbeheerDataLayerFactoryException : Exception
    {
        public AdresbeheerDataLayerFactoryException()
        {
        }

        public AdresbeheerDataLayerFactoryException(string? message) : base(message)
        {
        }

        public AdresbeheerDataLayerFactoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AdresbeheerDataLayerFactoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}