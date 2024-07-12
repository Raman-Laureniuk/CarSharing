namespace CarSharing.WebApi.Management.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Services.Car;
    using CarSharing.WebApi.Management.Mappers.Car.Request;
    using CarSharing.WebApi.Management.Mappers.Car.Response;
    using CarSharing.WebApi.Management.Messages.Car.Request;
    using CarSharing.WebApi.Management.Messages.Car.Response;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
        }

        [HttpPost]
        public async Task<ActionResult<AddCarResponseMessage>> AddCarAsync([FromBody] AddCarRequestMessage request)
        {
            AddCarResponseDto response = await _carService.AddCarAsync(request.ToAddCarRequestDto());

            return Ok(response.ToAddCarResponseMessage());
        }

        [HttpPut]
        public async Task<ActionResult<UpdateCarResponseMessage>> UpdateCarAsync([FromBody] UpdateCarRequestMessage request)
        {
            UpdateCarResponseDto response = await _carService.UpdateCarAsync(request.ToUpdateCarRequestDto());

            return Ok(response.ToUpdateCarResponseMessage());
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteCarResponseMessage>> DeleteCarAsync([FromQuery] Guid carId)
        {
            DeleteCarResponseDto response = await _carService.DeleteCarAsync(new DeleteCarRequestDto()
            {
                CarId = carId
            });

            return Ok(response.ToDeleteCarResponseMessage());
        }

        [HttpGet]
        public async Task<ActionResult<GetCarsResponseMessage>> GetCarsAsync()
        {
            GetCarsResponseDto response = await _carService.GetCarsAsync(new GetCarsRequestDto());

            return Ok(response.ToGetCarsResponseMessage());
        }
    }
}
