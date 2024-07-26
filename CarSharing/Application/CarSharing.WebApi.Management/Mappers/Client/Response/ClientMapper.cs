namespace CarSharing.WebApi.Management.Mappers.Client.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Tools.Extensions;
    using CarSharing.WebApi.Management.Messages.Client.Response;

    internal static class ClientMapper
    {
        public static ClientMessage ToClientMessage(this ClientDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ClientMessage()
            {
                ClientId = dto.ClientId,
                Name = dto.Name,
                Surname = dto.Surname,
                LicenseNumber = dto.LicenseNumber,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                IsActive = dto.IsActive,
                IsBlocked = dto.IsBlocked
            };
        }

        public static List<ClientMessage> ToClientMessage(this IEnumerable<ClientDto> dto)
        {
            return dto
                .OrEmptyIfNull()
                .Select(ToClientMessage)
                .ToList();
        }
    }
}
