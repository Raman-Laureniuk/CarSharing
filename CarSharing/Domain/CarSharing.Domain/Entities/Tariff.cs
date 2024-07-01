namespace CarSharing.Domain.Entities
{
    using System.Collections.Generic;

    public class Tariff
    {
        public int Id { get; set; }

        public decimal RatePerHour { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
