namespace CarSharing.WebApi.Geo.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Coordinates.Response;
    using CarSharing.Domain.Services.Coordinates;
    using CarSharing.WebApi.Common.Roles;
    using CarSharing.WebApi.Geo.Mappers.Request;
    using CarSharing.WebApi.Geo.Mappers.Response;
    using CarSharing.WebApi.Geo.Messages.Request;
    using CarSharing.WebApi.Geo.Messages.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CoordinatesController : ControllerBase
    {
        private readonly ICoordinatesService _coordinatesService;

        public CoordinatesController(ICoordinatesService coordinatesService)
        {
            _coordinatesService = coordinatesService ?? throw new ArgumentNullException(nameof(coordinatesService));
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleNames.Geo},{RoleNames.Admin}")]
        public async Task<ActionResult<AddOrUpdateCoordinatesResponseMessage>> AddOrUpdateCoordinatesAsync([FromBody] AddOrUpdateCoordinatesRequestMessage request)
        {
            AddUpdateCoordinatesResponseDto response = await _coordinatesService.AddOrUpdateCoordinatesAsync(request.ToAddOrUpdateCoordinatesRequestDto());

            return Ok(response.ToAddOrUpdateCoordinatesResponseMessage());
        }
    }
}
