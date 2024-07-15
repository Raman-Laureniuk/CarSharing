namespace CarSharing.Domain.Exceptions.Ride
{
    using System;

    internal class ClientNotActiveException : ApplicationException
    {
        public ClientNotActiveException()
            : base()
        {
        }

        public ClientNotActiveException(string message)
            : base(message)
        {
        }

        public ClientNotActiveException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
