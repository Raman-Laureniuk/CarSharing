namespace CarSharing.WebApi.Management.Messages.Car.Request
{
    public class AddCarRequestMessage
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
        public int TariffId { get; set; }
    }
}
