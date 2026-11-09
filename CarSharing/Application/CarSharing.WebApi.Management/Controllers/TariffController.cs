namespace CarSharing.WebApi.Management.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Services.Tariff;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Common.Mappers;
    using CarSharing.WebApi.Common.Validation.Attributes;
    using CarSharing.WebApi.Management.Constants;
    using CarSharing.WebApi.Management.Mappers.Tariff.Request;
    using CarSharing.WebApi.Management.Mappers.Tariff.Response;
    using CarSharing.WebApi.Management.Messages.Tariff.Request;
    using CarSharing.WebApi.Management.Messages.Tariff.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class TariffController : ControllerBase
    {
        private readonly ITariffService _tariffService;

        public TariffController(ITariffService tariffService)
        {
            _tariffService = tariffService ?? throw new ArgumentNullException(nameof(tariffService));
        }

        [HttpPost]
        [Authorize(Policy = PolicyNames.TARIFF_MANAGEMENT)]
        public async Task<ActionResult<AddTariffResponseMessage>> AddTariffAsync([FromBody][Required] AddTariffRequestMessage request)
        {
            Result<AddTariffResponseDto> result = await _tariffService.AddTariffAsync(request.ToAddTariffRequestDto());

            return result.ToActionResult();
        }

        [HttpPut]
        [Authorize(Policy = PolicyNames.TARIFF_MANAGEMENT)]
        public async Task<IActionResult> UpdateTariffAsync([FromBody][Required] UpdateTariffRequestMessage request)
        {
            Result result = await _tariffService.UpdateTariffAsync(request.ToUpdateTariffRequestDto());

            return result.ToActionResult();
        }

        [HttpDelete]
        [Authorize(Policy = PolicyNames.TARIFF_MANAGEMENT)]
        public async Task<IActionResult> DeleteTariffAsync([FromQuery][Required][ForbidDefaultValue] int tariffId)
        {
            Result result = await _tariffService.DeleteTariffAsync(new DeleteTariffRequestDto()
            {
                TariffId = tariffId
            });

            return result.ToActionResult();
        }

        [HttpGet]
        [Authorize(Policy = PolicyNames.STAFF)]
        public async Task<ActionResult<GetTariffsResponseMessage>> GetTariffsAsync()
        {
            Result<GetTariffsResponseDto> result = await _tariffService.GetTariffsAsync(new GetTariffsRequestDto());

            return result.ToActionResult();
        }
    }
}
