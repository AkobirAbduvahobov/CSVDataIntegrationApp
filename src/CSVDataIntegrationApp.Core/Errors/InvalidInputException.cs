using System.Runtime.Serialization;

namespace CSVDataIntegrationApp.Core.Errors;

public class InvalidInputException : Exception
{
    public InvalidInputException() { }
    public InvalidInputException(string message) : base(message) { }
    public InvalidInputException(string message, Exception inner) : base(message, inner) { }
    protected InvalidInputException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
