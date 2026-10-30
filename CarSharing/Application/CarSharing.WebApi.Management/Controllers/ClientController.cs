namespace CarSharing.WebApi.Management.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.Domain.Dto.Client.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Services.Client;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Common.Constants;
    using CarSharing.WebApi.Common.Validation.Attributes;
    using CarSharing.WebApi.Management.Constants;
    using CarSharing.WebApi.Management.Mappers.Client.Request;
    using CarSharing.WebApi.Management.Mappers.Client.Response;
    using CarSharing.WebApi.Management.Messages.Client.Request;
    using CarSharing.WebApi.Management.Messages.Client.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize(Policy = PolicyNames.CLIENT_MANAGEMENT)]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteClientAsync([FromQuery][Required][ForbidDefaultValue] Guid clientId)
        {
            Result result = await _clientService.DeleteClientAsync(new DeleteClientRequestDto()
            {
                ClientId = clientId
            });

            return result.IsSuccess ? Ok()
                                    : BadRequest(result.ErrorDetails.Message);
        }

        [HttpGet]
        public async Task<ActionResult<GetClientsResponseMessage>> GetClientsAsync([FromQuery]                 string orderBy       = nameof(Client.Surname),
                                                                                   [FromQuery]                 bool   sortAscending = ApiParametersConstants.DEFAULT_ASCEND_SORTING,
                                                                                   [FromQuery]                 int    offset        = ApiParametersConstants.DEFAULT_OFFSET,
                                                                                   [FromQuery][Range(1, 1000)] int    limit         = ApiParametersConstants.DEFAULT_LIMIT)
        {
            Result<GetClientsResponseDto> result = await _clientService.GetClientsAsync(new GetClientsRequestDto()
            {
                OrderBy = orderBy,
                SortAscending = sortAscending,
                Offset = offset,
                Limit = limit
            });

            return result.IsSuccess ? Ok        (result.Value.ToGetClientsResponseMessage())
                                    : BadRequest(result.ErrorDetails.Message);
        }

        [HttpPost]
        [Route("activate")]
        public async Task<ActionResult> ActivateClientAsync([FromBody][Required] ActivateClientRequestMessage request)
        {
            Result result = await _clientService.ActivateClientAsync(request.ToActivateClientRequestDto());

            return result.IsSuccess ? Ok()
                                    : BadRequest(result.ErrorDetails.Message);
        }

        [HttpPost]
        [Route("deactivate")]
        public async Task<ActionResult> DeactivateClientAsync([FromBody][Required] DeactivateClientRequestMessage request)
        {
            Result result = await _clientService.DeactivateClientAsync(request.ToDeactivateClientRequestDto());

            return result.IsSuccess ? Ok()
                                    : BadRequest(result.ErrorDetails.Message);
        }
    }
}
