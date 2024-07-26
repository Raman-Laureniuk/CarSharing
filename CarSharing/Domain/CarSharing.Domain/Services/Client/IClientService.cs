namespace CarSharing.Domain.Services.Client
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;

    public interface IClientService
    {
        Task<AddClientResponseDto> AddClientAsync(AddClientRequestDto request);
        Task<UpdateClientResponseDto> UpdateClientAsync(UpdateClientRequestDto request);
        Task<DeleteClientResponseDto> DeleteClientAsync(DeleteClientRequestDto request);
        Task<GetClientsResponseDto> GetClientsAsync(GetClientsRequestDto request);
        Task<ActivateClientResponseDto> ActivateClientAsync(ActivateClientRequestDto request);
        Task<DeactivateClientResponseDto> DeactivateClientAsync(DeactivateClientRequestDto request);
    }
}
