namespace CarSharing.Domain.Dto.Car.Request
{
    using System;

    public class UpdateCarRequestDto
    {
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
        public int? TariffId { get; set; }
    }
}
