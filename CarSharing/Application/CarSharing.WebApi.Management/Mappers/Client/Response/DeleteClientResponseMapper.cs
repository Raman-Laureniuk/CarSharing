namespace CarSharing.WebApi.Management.Mappers.Client.Response
{
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.WebApi.Management.Messages.Client.Response;
    
    internal static class DeleteClientResponseMapper
    {
        public static DeleteClientResponseMessage ToDeleteClientResponseMessage(this DeleteClientResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new DeleteClientResponseMessage()
            {
                Success = dto.Success
            };
        }
    }
}
