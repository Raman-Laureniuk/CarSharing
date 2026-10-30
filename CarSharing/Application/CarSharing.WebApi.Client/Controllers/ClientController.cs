namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Services.Client;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Client.Mappers.Client.Request;
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
        public async Task<ActionResult> AddClientAsync()
        {
            Result result = await _clientService.AddClientAsync(User.ToAddClientRequestDto());

            return result.IsSuccess ? Ok()
                                    : BadRequest(result.ErrorDetails.Message);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClientAsync()
        {
            Result result = await _clientService.UpdateClientAsync(User.ToUpdateClientRequestDto());

            return result.IsSuccess ? Ok()
                                    : BadRequest(result.ErrorDetails.Message);
        }
    }
}
