namespace CarSharing.Domain.Services.Wallet
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Tools.Result;

    public interface IWalletService
    {
        Task<Result<AddWalletResponseDto>> AddWalletAsync(AddWalletRequestDto request);
        Task<Result> DeleteWalletAsync(DeleteWalletRequestDto request);
        Task<Result<GetWalletsResponseDto>> GetWalletsAsync(GetWalletsRequestDto request);
        Task<Result<CheckWalletForClientResponseDto>> CheckWalletForClientAsync(CheckWalletForClientRequestDto request);
    }
}
