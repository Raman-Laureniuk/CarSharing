﻿namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Wallet.Request;
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

        [HttpPost]
        public async Task<ActionResult<AddWalletResponseMessage>> AddWalletAsync([FromBody] AddWalletRequestMessage request)
        {
            AddWalletResponseDto response = await _walletService.AddWalletAsync(request.ToAddWalletRequestDto());

            return Ok(response.ToAddWalletResponseMessage());
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteWalletResponseMessage>> DeleteWalletAsync([FromQuery] int walletId, [FromQuery] Guid clientId)
        {
            DeleteWalletResponseDto response = await _walletService.DeleteWalletAsync(new DeleteWalletRequestDto()
            {
                WalletId = walletId,
                ClientId = clientId
            });

            return Ok(response.ToDeleteWalletResponseMessage());
        }

        [HttpGet]
        public async Task<ActionResult<GetWalletsResponseMessage>> GetWalletsAsync([FromQuery] Guid clientId)
        {
            GetWalletsResponseDto response = await _walletService.GetWalletsAsync(new GetWalletsRequestDto()
            {
                ClientId = clientId
            });

            return Ok(response.ToGetWalletsResponseMessage());
        }
    }
}
