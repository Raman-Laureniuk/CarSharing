namespace CarSharing.Domain.Mappers.Client.Request
{
    using System;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Entities;

    internal static class AddClientRequestMapper
    {
        public static Client ToClientEntity(this AddClientRequestDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new Client()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                LicenseNumber = dto.LicenseNumber,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                IsActive = false,
                IsBlocked = false
            };
        }
    }
}
