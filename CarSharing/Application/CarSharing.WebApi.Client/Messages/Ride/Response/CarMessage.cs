namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;

    public class CarMessage
    {
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
    }
}
