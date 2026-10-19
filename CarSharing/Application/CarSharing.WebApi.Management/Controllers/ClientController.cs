namespace CarSharing.WebApi.Management.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Services.Client;
    using CarSharing.WebApi.Management.Constants;
    using CarSharing.WebApi.Management.Mappers.Client.Request;
    using CarSharing.WebApi.Management.Mappers.Client.Response;
    using CarSharing.WebApi.Management.Messages.Client.Request;
    using CarSharing.WebApi.Management.Messages.Client.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize(PolicyNames.CLIENT_MANAGEMENT)]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
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
        public async Task<ActionResult<GetClientsResponseMessage>> GetClientsAsync([FromQuery] string orderBy, [FromQuery] bool sortAscending, [FromQuery] int offset, [FromQuery] int limit)
        {
            GetClientsResponseDto response = await _clientService.GetClientsAsync(new GetClientsRequestDto()
            {
                OrderBy = orderBy,
                SortAscending = sortAscending,
                Offset = offset,
                Limit = limit
            });

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
