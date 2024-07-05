namespace CarSharing.Domain.Dto.Ride.Response
{
    using System;

    public class CarDto
    {
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
    }
}
