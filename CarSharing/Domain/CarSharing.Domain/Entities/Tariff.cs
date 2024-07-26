namespace CarSharing.Domain.Entities
{
    using System.Collections.Generic;

    public class Tariff
    {
        public int TariffId { get; set; }

        public decimal PricePerHour { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
