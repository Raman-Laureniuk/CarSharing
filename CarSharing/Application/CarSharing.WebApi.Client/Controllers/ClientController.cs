namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Services.Client;
    using CarSharing.WebApi.Client.Mappers.Client.Request;
    using CarSharing.WebApi.Client.Mappers.Client.Response;
    using CarSharing.WebApi.Client.Messages.Client.Request;
    using CarSharing.WebApi.Client.Messages.Client.Response;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        [HttpPost]
        [Route("client/register")]
        public async Task<ActionResult<AddClientResponseMessage>> AddClientAsync(AddClientRequestMessage request)
        {
            AddClientResponseDto response = await _clientService.AddClientAsync(request.ToAddClientRequestDto());

            return Ok(response.ToAddClientResponseMessage());
        }

        [HttpPut]
        [Route("client/update")]
        public async Task<ActionResult<UpdateClientResponseMessage>> UpdateClientAsync(UpdateClientRequestMessage request)
        {
            UpdateClientResponseDto response = await _clientService.UpdateClientAsync(request.ToUpdateClientRequestDto());

            return Ok(response.ToUpdateClientResponseMessage());
        }
    }
}
