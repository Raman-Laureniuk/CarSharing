namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Services.Client;
    using CarSharing.WebApi.Client.Mappers.Client.Request;
    using CarSharing.WebApi.Client.Mappers.Client.Response;
    using CarSharing.WebApi.Client.Messages.Client.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        [HttpPost]
        public async Task<ActionResult<AddClientResponseMessage>> AddClientAsync()
        {
            AddClientResponseDto response = await _clientService.AddClientAsync(User.ToAddClientRequestDto());

            return Ok(response.ToAddClientResponseMessage());
        }

        [HttpPut]
        public async Task<ActionResult<UpdateClientResponseMessage>> UpdateClientAsync()
        {
            UpdateClientResponseDto response = await _clientService.UpdateClientAsync(User.ToUpdateClientRequestDto());

            return Ok(response.ToUpdateClientResponseMessage());
        }
    }
}
