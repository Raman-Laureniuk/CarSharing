namespace CarSharing.WebApi.Management.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Services.Car;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Common.Constants;
    using CarSharing.WebApi.Common.Validation.Attributes;
    using CarSharing.WebApi.Management.Constants;
    using CarSharing.WebApi.Management.Mappers.Car.Request;
    using CarSharing.WebApi.Management.Mappers.Car.Response;
    using CarSharing.WebApi.Management.Messages.Car.Request;
    using CarSharing.WebApi.Management.Messages.Car.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
        }

        [HttpPost]
        [Authorize(Policy = PolicyNames.CAR_MANAGEMENT)]
        public async Task<ActionResult<AddCarResponseMessage>> AddCarAsync([FromBody][Required] AddCarRequestMessage request)
        {
            Result<AddCarResponseDto> result = await _carService.AddCarAsync(request.ToAddCarRequestDto());

            return result.IsSuccess ? Ok        (result.Value.ToAddCarResponseMessage())
                                    : BadRequest(result.ErrorDetails.Message);
        }

        [HttpPut]
        [Authorize(Policy = PolicyNames.CAR_MANAGEMENT)]
        public async Task<ActionResult> UpdateCarAsync([FromBody][Required] UpdateCarRequestMessage request)
        {
            Result result = await _carService.UpdateCarAsync(request.ToUpdateCarRequestDto());

            return result.IsSuccess ? Ok()
                                    : BadRequest(result.ErrorDetails.Message);
        }

        [HttpDelete]
        [Authorize(Policy = PolicyNames.CAR_MANAGEMENT)]
        public async Task<ActionResult> DeleteCarAsync([FromQuery][Required][ForbidDefaultValue] Guid carId)
        {
            Result result = await _carService.DeleteCarAsync(new DeleteCarRequestDto()
            {
                CarId = carId
            });

            return result.IsSuccess ? Ok()
                                    : BadRequest(result.ErrorDetails.Message);
        }

        [HttpGet]
        [Authorize(Policy = PolicyNames.STAFF)]
        public async Task<ActionResult<GetCarsResponseMessage>> GetCarsAsync([FromQuery]                 string orderBy        = nameof(Car.Model),
                                                                             [FromQuery]                 bool   sortAscending  = ApiParametersConstants.DEFAULT_ASCEND_SORTING,
                                                                             [FromQuery]                 int    offset         = ApiParametersConstants.DEFAULT_OFFSET,
                                                                             [FromQuery][Range(1, 1000)] int    limit          = ApiParametersConstants.DEFAULT_LIMIT)
        {
            Result<GetCarsResponseDto> result = await _carService.GetCarsAsync(new GetCarsRequestDto()
            {
                IsAvailable = null,
                OrderBy = orderBy,
                SortAscending = sortAscending,
                Offset = offset,
                Limit = limit
            });

            return result.IsSuccess ? Ok        (result.Value.ToGetCarsResponseMessage())
                                    : BadRequest(result.ErrorDetails.Message);
        }
    }
}
