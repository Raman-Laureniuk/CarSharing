namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Services.Wallet;
    using CarSharing.WebApi.Client.Mappers.Wallet.Request;
    using CarSharing.WebApi.Client.Mappers.Wallet.Response;
    using CarSharing.WebApi.Client.Messages.Wallet.Request;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService ?? throw new ArgumentNullException(nameof(walletService));
        }

        public async Task<ActionResult<AddWalletResponseMessage>> AddWalletAsync(AddWalletRequestMessage request)
        {
            AddWalletResponseDto response = await _walletService.AddWalletAsync(request.ToAddWalletRequestDto());

            return Ok(response.ToAddWalletResponseMessage());
        }

        public async Task<ActionResult<DeleteWalletResponseMessage>> DeleteWalletAsync(DeleteWalletRequestMessage request)
        {
            DeleteWalletResponseDto response = await _walletService.DeleteWalletAsync(request.ToDeleteWalletRequestDto());

            return Ok(response.ToDeleteWalletResponseMessage());
        }

        public async Task<ActionResult<GetWalletsResponseMessage>> GetWalletsAsync(GetWalletsRequestMessage request)
        {
            GetWalletsResponseDto response = await _walletService.GetWalletsAsync(request.ToGetWalletsRequestDto());

            return Ok(response.ToGetWalletsResponseMessage());
        }
    }
}
