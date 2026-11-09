namespace CarSharing.Domain.Services.Client
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Tools.Result;

    public interface IClientService
    {
        Task<Result> AddClientAsync(AddClientRequestDto request);
        Task<Result> UpdateClientAsync(UpdateClientRequestDto request);
        Task<Result> DeleteClientAsync(DeleteClientRequestDto request);
        Task<Result<GetClientsResponseDto>> GetClientsAsync(GetClientsRequestDto request);
        Task<Result> ActivateClientAsync(ActivateClientRequestDto request);
        Task<Result> DeactivateClientAsync(DeactivateClientRequestDto request);
    }
}
