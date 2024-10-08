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
    using CarSharing.WebApi.Common.Claims;
    using CarSharing.WebApi.Common.Roles;
    using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = RoleNames.User)]
        public async Task<ActionResult<AddWalletResponseMessage>> AddWalletAsync([FromBody] AddWalletRequestMessage request)
        {
            Guid clientId = ClaimsHelper.GetClientId(User);
            
            AddWalletResponseDto response = await _walletService.AddWalletAsync(request.ToAddWalletRequestDto(clientId));

            return Ok(response.ToAddWalletResponseMessage());
        }

        [HttpDelete]
        [Authorize(Roles = RoleNames.User)]
        public async Task<ActionResult<DeleteWalletResponseMessage>> DeleteWalletAsync([FromQuery] int walletId)
        {
            Guid clientId = ClaimsHelper.GetClientId(User);
            
            DeleteWalletResponseDto response = await _walletService.DeleteWalletAsync(new DeleteWalletRequestDto()
            {
                WalletId = walletId,
                ClientId = clientId
            });

            return Ok(response.ToDeleteWalletResponseMessage());
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.User)]
        public async Task<ActionResult<GetWalletsResponseMessage>> GetWalletsAsync()
        {
            Guid clientId = ClaimsHelper.GetClientId(User);
            
            GetWalletsResponseDto response = await _walletService.GetWalletsAsync(new GetWalletsRequestDto()
            {
                ClientId = clientId
            });

            return Ok(response.ToGetWalletsResponseMessage());
        }
    }
}
