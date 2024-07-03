namespace CarSharing.Domain.Services.Wallet
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;

    public interface IWalletService
    {
        Task<AddWalletResponseDto> AddWalletAsync(AddWalletRequestDto request);
        Task<DeleteWalletResponseDto> DeleteWalletAsync(DeleteWalletRequestDto request);
        Task<GetWalletsResponseDto> GetWalletsAsync(GetWalletsRequestDto request);
    }
}
