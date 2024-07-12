﻿namespace CarSharing.WebApi.Geo.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Coordinates.Response;
    using CarSharing.Domain.Services.Coordinates;
    using CarSharing.WebApi.Geo.Mappers.Request;
    using CarSharing.WebApi.Geo.Mappers.Response;
    using CarSharing.WebApi.Geo.Messages.Request;
    using CarSharing.WebApi.Geo.Messages.Response;
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
        public async Task<ActionResult<AddOrUpdateCoordinatesResponseMessage>> AddOrUpdateCoordinatesAsync([FromBody] AddOrUpdateCoordinatesRequestMessage request)
        {
            AddUpdateCoordinatesResponseDto response = await _coordinatesService.AddOrUpdateCoordinatesAsync(request.ToAddOrUpdateCoordinatesRequestDto());

            return Ok(response.ToAddOrUpdateCoordinatesResponseMessage());
        }
    }
}
