namespace CarSharing.WebApi.Geo.Messages.Request
{
    using System;

    public class AddOrUpdateCoordinatesRequestMessage
    {
        public Guid CarId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
