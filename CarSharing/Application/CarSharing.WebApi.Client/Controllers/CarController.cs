namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Services.Car;
    using CarSharing.WebApi.Client.Mappers.Car.Response;
    using CarSharing.WebApi.Client.Messages.Car.Response;
    using CarSharing.WebApi.Common.Roles;
    using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize(Roles = RoleNames.User)]
        public async Task<ActionResult<GetCarsResponseMessage>> GetCarsAsync()
        {
            GetCarsResponseDto response = await _carService.GetCarsAsync(new GetCarsRequestDto()
            {
                isAvailable = true
            });

            return Ok(response.ToGetCarsResponseMessage());
        }
    }
}
