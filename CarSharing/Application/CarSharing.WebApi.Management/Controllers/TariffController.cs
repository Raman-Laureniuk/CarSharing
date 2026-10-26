namespace CarSharing.WebApi.Management.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Services.Tariff;
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
        [Authorize(PolicyNames.TARIFF_MANAGEMENT)]
        public async Task<ActionResult<AddTariffResponseMessage>> AddTariffAsync([FromBody] AddTariffRequestMessage request)
        {
            AddTariffResponseDto response = await _tariffService.AddTariffAsync(request.ToAddTariffRequestDto());

            return Ok(response.ToAddTariffResponseMessage());
        }

        [HttpPut]
        [Authorize(PolicyNames.TARIFF_MANAGEMENT)]
        public async Task<ActionResult<UpdateTariffResponseMessage>> UpdateTariffAsync([FromBody] UpdateTariffRequestMessage request)
        {
            UpdateTariffResponseDto response = await _tariffService.UpdateTariffAsync(request.ToUpdateTariffRequestDto());

            return Ok(response.ToUpdateTariffResponseMessage());
        }

        [HttpDelete]
        [Authorize(PolicyNames.TARIFF_MANAGEMENT)]
        public async Task<ActionResult<DeleteTariffResponseMessage>> DeleteTariffAsync([FromQuery][Required][ForbidDefaultValue] int tariffId)
        {
            DeleteTariffResponseDto response = await _tariffService.DeleteTariffAsync(new DeleteTariffRequestDto()
            {
                TariffId = tariffId
            });

            return Ok(response.ToDeleteTariffResponseMessage());
        }

        [HttpGet]
        [Authorize(Policy = PolicyNames.STAFF)]
        public async Task<ActionResult<GetTariffsResponseMessage>> GetTariffsAsync()
        {
            GetTariffsResponseDto response = await _tariffService.GetTariffsAsync(new GetTariffsRequestDto());

            return Ok(response.ToGetTariffsResponseMessage());
        }
    }
}
