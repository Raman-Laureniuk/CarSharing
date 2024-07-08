namespace CarSharing.Domain.Services.Tariff.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Tariff;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;

    internal class TariffService : ITariffService
    {
        private readonly IAddTariffCommandAsync _addTariffCommand;
        private readonly IDeleteTariffCommandAsync _deleteTariffCommand;
        private readonly IGetTariffsCommandAsync _getTariffsCommand;
        private readonly IUpdateTariffCommandAsync _updateTariffCommand;
        private readonly ICalculatePriceCommand _calculatePriceCommand;

        public TariffService(IAddTariffCommandAsync addTariffCommand,
            IDeleteTariffCommandAsync deleteTariffCommand,
            IGetTariffsCommandAsync getTariffsCommand,
            IUpdateTariffCommandAsync updateTariffCommand,
            ICalculatePriceCommand calculatePriceCommand)
        {
            _addTariffCommand = addTariffCommand ?? throw new ArgumentNullException(nameof(addTariffCommand));
            _deleteTariffCommand = deleteTariffCommand ?? throw new ArgumentNullException(nameof(deleteTariffCommand));
            _getTariffsCommand = getTariffsCommand ?? throw new ArgumentNullException(nameof(getTariffsCommand));
            _updateTariffCommand = updateTariffCommand ?? throw new ArgumentNullException(nameof(updateTariffCommand));
            _calculatePriceCommand = calculatePriceCommand ?? throw new ArgumentNullException(nameof(calculatePriceCommand));
        }

        public Task<AddTariffResponseDto> AddTariffAsync(AddTariffRequestDto request)
        {
            return _addTariffCommand.ExecuteAsync(request);
        }

        public CalculatePriceResponseDto CalculatePrice(CalculatePriceRequestDto request)
        {
            return _calculatePriceCommand.Execute(request);
        }

        public Task<DeleteTariffResponseDto> DeleteTariffAsync(DeleteTariffRequestDto request)
        {
            return _deleteTariffCommand.ExecuteAsync(request);
        }

        public Task<GetTariffsResponseDto> GetTariffsAsync(GetTariffsRequestDto request)
        {
            return _getTariffsCommand.ExecuteAsync(request);
        }

        public Task<UpdateTariffResponseDto> UpdateTariffAsync(UpdateTariffRequestDto request)
        {
            return _updateTariffCommand.ExecuteAsync(request);
        }
    }
}
