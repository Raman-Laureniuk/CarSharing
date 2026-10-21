namespace CarSharing.WebApi.Client.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Services.Car;
    using CarSharing.WebApi.Client.Mappers.Car.Response;
    using CarSharing.WebApi.Client.Messages.Car.Response;

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
        }

        [HttpGet]
        public async Task<ActionResult<GetCarsResponseMessage>> GetAvailableCarsAsync([FromQuery] string orderBy       = nameof(Car.Tariff.PricePerHour),
                                                                                      [FromQuery] bool   sortAscending = true,
                                                                                      [FromQuery] int    offset        = 0,
                                                                                      [FromQuery] int    limit         = 20)
        {
            GetCarsResponseDto response = await _carService.GetCarsAsync(new GetCarsRequestDto()
            {
                IsAvailable   = true,
                OrderBy       = orderBy,
                SortAscending = sortAscending,
                Offset        = offset,
                Limit         = limit
            });

            return Ok(response.ToGetCarsResponseMessage());
        }
    }
}
