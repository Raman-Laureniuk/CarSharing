namespace CarSharing.Domain.Dto.Client.Response
{
    using System.Collections.Generic;

    public class GetClientsResponseDto
    {
        public List<ClientDto> Clients { get; set; }
    }
}
