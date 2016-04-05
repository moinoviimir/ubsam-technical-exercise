using System;

namespace Equities.Infrastructure
{
    public sealed class ModelValidationException : Exception
    {
        private const string DefaultExceptionMessage = "Unexpected user input.";

        public ModelValidationException(string message)
            : base (message)
        {
            
        }

        public ModelValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }

        public ModelValidationException()
            : base(DefaultExceptionMessage)
        {
        }
    }
}
