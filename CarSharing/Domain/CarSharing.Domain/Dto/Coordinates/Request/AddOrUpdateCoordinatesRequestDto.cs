namespace CarSharing.Domain.Dto.Coordinates.Request
{
    using System;

    public class AddOrUpdateCoordinatesRequestDto
    {
        public Guid CarId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
