namespace CarSharing.Domain.Entities
{
    using System;

    public class CarCoordinates
    {
        public Guid CarId { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual Car Car { get; set; }
    }
}
