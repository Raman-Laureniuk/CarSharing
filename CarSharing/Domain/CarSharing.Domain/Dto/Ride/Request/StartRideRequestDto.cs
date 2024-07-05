namespace CarSharing.Domain.Dto.Ride.Request
{
    using System;

    public class StartRideRequestDto
    {
        public Guid ClientId { get; set; }
        public int WalletId { get; set; }
        public Guid CarId { get; set; }
    }
}
