namespace CarSharing.WebApi.Client.Messages.Ride.Request
{
    using System;

    public class StartRideRequestMessage
    {
        public int WalletId { get; set; }
        public Guid CarId { get; set; }
    }
}
