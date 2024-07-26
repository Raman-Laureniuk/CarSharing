namespace CarSharing.Domain.Exceptions
{
    using System;

    public class WrongStatusException : ApplicationException
    {
        public WrongStatusException()
            : base()
        {
        }

        public WrongStatusException(string message)
            : base(message)
        {
        }

        public WrongStatusException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
