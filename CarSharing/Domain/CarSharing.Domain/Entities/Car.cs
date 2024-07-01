namespace CarSharing.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        public Guid Id { get; set; }

        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
        public int TariffId { get; set; }

        public virtual Tariff Tariff { get; set; }
        public virtual CarCoordinates Coordinates { get; set; }
        public virtual ICollection<CarUsage> CarUsages { get; set; }
    }
}
