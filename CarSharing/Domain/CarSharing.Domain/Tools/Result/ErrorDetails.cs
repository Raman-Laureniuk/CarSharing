namespace CarSharing.Domain.Tools.Result
{
    using System;

    public class ErrorDetails
    {
        public ErrorType ErrorType { get; }
        public string    Message   { get; }

        public ErrorDetails(ErrorType errorType, string message)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(message);

            ErrorType = errorType;
            Message   = message;
        }
    }
}
