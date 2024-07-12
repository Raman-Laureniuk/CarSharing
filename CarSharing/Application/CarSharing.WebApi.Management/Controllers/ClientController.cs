namespace CarSharing.WebApi.Management.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Services.Client;
    using CarSharing.WebApi.Management.Mappers.Client.Request;
    using CarSharing.WebApi.Management.Mappers.Client.Response;
    using CarSharing.WebApi.Management.Messages.Client.Request;
    using CarSharing.WebApi.Management.Messages.Client.Response;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        [HttpPost]
        public async Task<ActionResult<AddClientResponseMessage>> AddClientAsync([FromBody] AddClientRequestMessage request)
        {
            AddClientResponseDto response = await _clientService.AddClientAsync(request.ToAddClientRequestDto());

            return Ok(response.ToAddClientResponseMessage());
        }

        [HttpPut]
        public async Task<ActionResult<UpdateClientResponseMessage>> UpdateClientAsync([FromBody] UpdateClientRequestMessage request)
        {
            UpdateClientResponseDto response = await _clientService.UpdateClientAsync(request.ToUpdateClientRequestDto());

            return Ok(response.ToUpdateClientResponseMessage());
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteClientResponseMessage>> DeleteClientAsync([FromQuery] Guid clientId)
        {
            DeleteClientResponseDto response = await _clientService.DeleteClientAsync(new DeleteClientRequestDto()
            {
                ClientId = clientId
            });

            return Ok(response.ToDeleteClientResponseMessage());
        }

        [HttpGet]
        public async Task<ActionResult<GetClientsResponseMessage>> GetClientsAsync()  // TODO: offset/limit
        {
            GetClientsResponseDto response = await _clientService.GetClientsAsync(new GetClientsRequestDto());

            return Ok(response.ToGetClientsResponseMessage());
        }

        [HttpPost]
        [Route("activate")]
        public async Task<ActionResult<ActivateClientResponseMessage>> ActivateClientAsync([FromBody] ActivateClientRequestMessage request)
        {
            ActivateClientResponseDto response = await _clientService.ActivateClientAsync(request.ToActivateClientRequestDto());

            return Ok(response.ToActivateClientResponseMessage());
        }

        [HttpPost]
        [Route("deactivate")]
        public async Task<ActionResult<DeactivateClientResponseMessage>> DeactivateClientAsync([FromBody] DeactivateClientRequestMessage request)
        {
            DeactivateClientResponseDto response = await _clientService.DeactivateClientAsync(request.ToDeactivateClientRequestDto());

            return Ok(response.ToDeactivateClientResponseMessage());
        }
    }
}
