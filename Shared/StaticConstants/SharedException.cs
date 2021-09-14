using System;
using System.Runtime.Serialization;

namespace Shared.StaticConstants
{  

    /// <summary>
    /// Defines the <see cref="SharedException" />
    /// </summary>
    [Serializable]
    public class SharedException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuluCRMException"/> class.
        /// </summary>
        /// <param name="info">The info<see cref="SerializationInfo"/></param>
        /// <param name="context">The context<see cref="StreamingContext"/></param>
        protected SharedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuluCRMException"/> class.
        /// </summary>
        public SharedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuluCRMException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public SharedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuluCRMException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="inner">The inner<see cref="System.Exception"/></param>
        public SharedException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
