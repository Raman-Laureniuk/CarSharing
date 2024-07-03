namespace CarSharing.Domain.Mappers.Client.Response
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Tools.Extensions;

    internal static class GetClientResponseMapper
    {
        public static ClientDto ToClientDto(this Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return new ClientDto()
            {
                ClientId = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                LicenseNumber = client.LicenseNumber,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                IsConfirmed = client.IsConfirmed,
                IsBlocked = client.IsBlocked
            };
        }

        public static List<ClientDto> ToClientDto(this IEnumerable<Client> clients)
        {
            return clients
                .OrEmptyIfNull()
                .Select(ToClientDto)
                .ToList();
        }

        public static GetClientsResponseDto ToGetClientsResponseDto(this IEnumerable<Client> clients)
        {
            return new GetClientsResponseDto()
            {
                Clients = clients.ToClientDto()
            };
        }
    }
}
