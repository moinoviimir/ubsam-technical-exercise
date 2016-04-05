using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities
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
