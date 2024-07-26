namespace CarSharing.WebApi.Management.Mappers.Client.Response
{
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.WebApi.Management.Messages.Client.Response;
    
    internal static class GetClientsResponseMapper
    {
        public static GetClientsResponseMessage ToGetClientsResponseMessage(this GetClientsResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new GetClientsResponseMessage()
            {
                Clients = dto.Clients.ToClientMessage()
            };
        }
    }
}
