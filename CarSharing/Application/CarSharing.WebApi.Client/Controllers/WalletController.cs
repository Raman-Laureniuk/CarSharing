namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Wallet.Request;
    using CarSharing.Domain.Dto.Wallet.Response;
    using CarSharing.Domain.Services.Wallet;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Client.Mappers.Wallet.Request;
    using CarSharing.WebApi.Client.Mappers.Wallet.Response;
    using CarSharing.WebApi.Client.Messages.Wallet.Request;
    using CarSharing.WebApi.Client.Messages.Wallet.Response;
    using CarSharing.WebApi.Common.Claims;
    using CarSharing.WebApi.Common.Validation.Attributes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService ?? throw new ArgumentNullException(nameof(walletService));
        }

        [HttpPost]
        public async Task<ActionResult<AddWalletResponseMessage>> AddWalletAsync([FromBody][Required] AddWalletRequestMessage request)
        {
            Guid clientId = ClaimsHelper.GetClientId(User);
            
            Result<AddWalletResponseDto> result = await _walletService.AddWalletAsync(request.ToAddWalletRequestDto(clientId));

            return result.IsSuccess ? Ok        (result.Value.ToAddWalletResponseMessage())
                                    : BadRequest(result.ErrorDetails.Message);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteWalletAsync([FromQuery][Required][ForbidDefaultValue] int walletId)
        {
            Guid clientId = ClaimsHelper.GetClientId(User);
            
            Result result = await _walletService.DeleteWalletAsync(new DeleteWalletRequestDto()
            {
                WalletId = walletId,
                ClientId = clientId
            });

            return result.IsSuccess ? Ok()
                                    : BadRequest(result.ErrorDetails.Message);
        }

        [HttpGet]
        public async Task<ActionResult<GetWalletsResponseMessage>> GetWalletsAsync()
        {
            Guid clientId = ClaimsHelper.GetClientId(User);
            
            Result<GetWalletsResponseDto> result = await _walletService.GetWalletsAsync(new GetWalletsRequestDto()
            {
                ClientId = clientId
            });

            return result.IsSuccess ? Ok        (result.Value.ToGetWalletsResponseMessage())
                                    : BadRequest(result.ErrorDetails.Message);
        }
    }
}
