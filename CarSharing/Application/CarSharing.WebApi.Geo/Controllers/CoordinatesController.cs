namespace CarSharing.WebApi.Geo.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using CarSharing.Domain.Services.Coordinates;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Geo.Mappers.Request;
    using CarSharing.WebApi.Geo.Messages.Coordinates.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CoordinatesController : ControllerBase
    {
        private readonly ICoordinatesService _coordinatesService;

        public CoordinatesController(ICoordinatesService coordinatesService)
        {
            _coordinatesService = coordinatesService ?? throw new ArgumentNullException(nameof(coordinatesService));
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateCoordinatesAsync([FromBody][Required] AddOrUpdateCoordinatesRequestMessage request)
        {
            Result result = await _coordinatesService.AddOrUpdateCoordinatesAsync(request.ToAddOrUpdateCoordinatesRequestDto());

            return result.IsSuccess ? Ok()
                                    : BadRequest(result.ErrorDetails.Message);
        }
    }
}
