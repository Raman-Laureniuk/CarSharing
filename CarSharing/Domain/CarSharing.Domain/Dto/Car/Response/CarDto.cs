namespace CarSharing.Domain.Dto.Car.Response
{
    public class CarDto
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
