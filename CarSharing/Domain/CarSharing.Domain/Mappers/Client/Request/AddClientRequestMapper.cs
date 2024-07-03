namespace CarSharing.Domain.Mappers.Client.Request
{
    using System;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Entities;

    internal static class AddClientRequestMapper
    {
        public static Client ToClientEntity(this AddClientRequestDto addClientRequestDto)
        {
            if (addClientRequestDto == null)
            {
                throw new ArgumentNullException(nameof(addClientRequestDto));
            }

            return new Client()
            {
                Name = addClientRequestDto.Name,
                Surname = addClientRequestDto.Surname,
                LicenseNumber = addClientRequestDto.LicenseNumber,
                PhoneNumber = addClientRequestDto.PhoneNumber,
                Email = addClientRequestDto.Email,
                IsConfirmed = false,
                IsBlocked = false
            };
        }
    }
}
