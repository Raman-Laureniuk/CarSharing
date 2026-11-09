namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Services.Client;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Client.Mappers.Client.Request;
    using CarSharing.WebApi.Common.Mappers;
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
        public async Task<IActionResult> AddClientAsync()
        {
            Result result = await _clientService.AddClientAsync(User.ToAddClientRequestDto());

            return result.ToActionResult();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClientAsync()
        {
            Result result = await _clientService.UpdateClientAsync(User.ToUpdateClientRequestDto());

            return result.ToActionResult();
        }
    }
}
