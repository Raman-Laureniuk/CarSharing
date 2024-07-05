namespace CarSharing.Domain.Entities
{
    using System.Collections.Generic;
    
    public class CarUsageStatus
    {
        public int Id { get; set; }

        public string NameKey { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<Ride> CarUsages { get; set; }
    }
}
