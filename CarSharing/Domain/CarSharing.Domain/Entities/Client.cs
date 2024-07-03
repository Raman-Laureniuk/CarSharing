﻿namespace CarSharing.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Client
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }

        public virtual ICollection<Wallet> Wallets { get; set; }
        public virtual ICollection<CarUsage> CarUsages { get; set; }
    }
}
