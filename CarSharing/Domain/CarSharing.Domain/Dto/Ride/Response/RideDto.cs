namespace CarSharing.Domain.Dto.Ride.Response
{
    using System;

    public class RideDto
    {
        public int RideId { get; set; }
        public Guid ClientId { get; set; }
        public int WalletId { get; set; }
        public CarDto Car { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
