namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Services.Ride;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Client.Mappers.Ride.Request;
    using CarSharing.WebApi.Client.Mappers.Ride.Response;
    using CarSharing.WebApi.Client.Messages.Ride.Request;
    using CarSharing.WebApi.Client.Messages.Ride.Response;
    using CarSharing.WebApi.Common.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RideController : ControllerBase
    {
        private readonly IRideService _rideService;

        public RideController(IRideService rideService)
        {
            _rideService = rideService ?? throw new ArgumentNullException(nameof(rideService));
        }

        [HttpPost]
        [Route("start")]
        public async Task<ActionResult<StartRideResponseMessage>> StartRideAsync([FromBody][Required] StartRideRequestMessage request)
        {
            Guid clientId = ClaimsHelper.GetClientId(User);
            
            Result<StartRideResponseDto> result = await _rideService.StartRideAsync(request.ToStartRideRequestDto(clientId));

            return result.IsSuccess ? Ok        (result.Value.ToStartRideResponseMessage())
                                    : BadRequest(result.ErrorDetails.Message);
        }

        [HttpPost]
        [Route("end")]
        public async Task<ActionResult<EndRideResponseMessage>> EndRideAsync([FromBody][Required] EndRideRequestMessage request)
        {
            Guid clientId = ClaimsHelper.GetClientId(User);

            Result<EndRideResponseDto> result = await _rideService.EndRideAsync(request.ToEndRideRequestDto(clientId));

            return result.IsSuccess ? Ok        (result.Value.ToEndRideResponseMessage())
                                    : BadRequest(result.ErrorDetails.Message);
        }

        [HttpGet]
        public async Task<ActionResult<GetRideHistoryResponseMessage>> GetRideHistoryAsync()
        {
            Guid clientId = ClaimsHelper.GetClientId(User);

            Result<GetRideHistoryResponseDto> result = await _rideService.GetRideHistoryAsync(new GetRideHistoryRequestDto()
            {
                ClientId = clientId
            });

            return result.IsSuccess ? Ok        (result.Value.ToGetRideHistoryResponseMessage())
                                    : BadRequest(result.ErrorDetails.Message);
        }
    }
}
