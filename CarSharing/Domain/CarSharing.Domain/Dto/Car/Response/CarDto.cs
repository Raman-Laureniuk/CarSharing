namespace CarSharing.Domain.Dto.Car.Response
{
    using System;

    public class CarDto
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
