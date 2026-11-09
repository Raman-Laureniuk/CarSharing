namespace CarSharing.WebApi.Management.Mappers.Client.Response
{
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Common.Mappers;
    using CarSharing.WebApi.Management.Messages.Client.Response;
    using Microsoft.AspNetCore.Mvc;

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
                Clients = dto.Clients.ToClientResponseMessage()
            };
        }

        public static ActionResult<GetClientsResponseMessage> ToActionResult(this Result<GetClientsResponseDto> result)
        {
            return result.ToActionResult(ToGetClientsResponseMessage);
        }
    }
}
