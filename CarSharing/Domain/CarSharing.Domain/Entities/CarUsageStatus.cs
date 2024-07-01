namespace CarSharing.Domain.Entities
{
    using System.Collections.Generic;
    
    public class CarUsageStatus
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CarUsage> CarUsages { get; set; }
    }
}
