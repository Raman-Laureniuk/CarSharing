namespace CarSharing.Domain.Mappers.Client.Request
{
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Entities;

    internal static class AddClientRequestMapper
    {
        public static Client ToClientEntity(this AddClientRequestDto dto)
        {
            if (dto == null)
            {
                return null;
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
