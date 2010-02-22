#region

using System;
using System.Runtime.Serialization;

#endregion

namespace Singleton.Helpers
{
    [Serializable]
    public class TypeCreationException : Exception
    {
        public TypeCreationException()
        {
        }

        public TypeCreationException(string message) : base(message)
        {
        }

        public TypeCreationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TypeCreationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}