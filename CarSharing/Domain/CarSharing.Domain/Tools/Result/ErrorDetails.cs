namespace CarSharing.Domain.Tools.Result
{
    using System;

    public class ErrorDetails
    {
        public string Message { get; }

        public ErrorDetails(string message)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(message);

            Message = message;
        }
    }
}
