namespace CarSharing.Domain.Mappers.Client.Request
{
    using System;
    using System.Linq.Expressions;
    using CarSharing.Domain.Entities;

    internal static class ClientOrderByMapper
    {
        public static Expression<Func<Client, object>> ToSortKeySelector(this string key)
        {
            return key switch
            {
                nameof(Client.ClientId) =>          x => x.ClientId,
                nameof(Client.Name) =>              x => x.Name,
                nameof(Client.Surname) =>           x => x.Surname,
                nameof(Client.LicenseNumber) =>     x => x.LicenseNumber,
                nameof(Client.PhoneNumber) =>       x => x.PhoneNumber,
                nameof(Client.Email) =>             x => x.Email,
                _ =>                                throw new ArgumentOutOfRangeException(nameof(key))
            };
        }
    }
}
