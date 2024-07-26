namespace CarSharing.Domain.Exceptions
{
    using System;

    public class CarInUseException : ApplicationException
    {
        public CarInUseException()
            : base()
        {
        }

        public CarInUseException(string message)
            : base(message)
        {
        }

        public CarInUseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
