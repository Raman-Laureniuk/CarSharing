namespace CarSharing.WebApi.Management.Messages.Car.Response
{
    using System;

    public class CarMessage
    {
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
