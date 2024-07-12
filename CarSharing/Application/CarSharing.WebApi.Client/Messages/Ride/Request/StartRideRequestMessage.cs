namespace CarSharing.WebApi.Client.Messages.Ride.Request
{
    using System;

    public class StartRideRequestMessage
    {
        public Guid ClientId { get; set; }  // TODO: Remove ClientId after auth implementation
        public int WalletId { get; set; }
        public Guid CarId { get; set; }
    }
}
