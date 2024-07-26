namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Services.Ride;
    using CarSharing.WebApi.Client.Mappers.Ride.Request;
    using CarSharing.WebApi.Client.Mappers.Ride.Response;
    using CarSharing.WebApi.Client.Messages.Ride.Request;
    using CarSharing.WebApi.Client.Messages.Ride.Response;
    using CarSharing.WebApi.Common.Claims;
    using CarSharing.WebApi.Common.Roles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IRideService _rideService;

        public RideController(IRideService rideService)
        {
            _rideService = rideService ?? throw new ArgumentNullException(nameof(rideService));
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.User)]
        [Route("start")]
        public async Task<ActionResult<StartRideResponseMessage>> StartRideAsync([FromBody] StartRideRequestMessage request)
        {
            Guid clientId = ClaimsHelper.GetClientId(User);
            
            StartRideResponseDto response = await _rideService.StartRideAsync(request.ToStartRideRequestDto(clientId));

            return Ok(response.ToStartRideResponseMessage());
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.User)]
        [Route("end")]
        public async Task<ActionResult<EndRideResponseMessage>> EndRideAsync([FromBody] EndRideRequestMessage request)
        {
            Guid clientId = ClaimsHelper.GetClientId(User);

            EndRideResponseDto response = await _rideService.EndRideAsync(request.ToEndRideRequestDto(clientId));

            return Ok(response.ToEndRideResponseMessage());
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.User)]
        public async Task<ActionResult<GetRideHistoryResponseMessage>> GetRideHistoryAsync()
        {
            Guid clientId = ClaimsHelper.GetClientId(User);

            GetRideHistoryResponseDto response = await _rideService.GetRideHistoryAsync(new GetRideHistoryRequestDto()
            {
                ClientId = clientId
            });

            return Ok(response.ToGetRideHistoryResponseMessage());
        }
    }
}
