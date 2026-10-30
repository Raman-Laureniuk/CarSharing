namespace CarSharing.Domain.Commands.Tariff.Impl
{
    using System;
    using CarSharing.Domain.Constants;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Tools.Result;

    internal class CalculatePriceCommand : ICalculatePriceCommand
    {
        public Result<CalculatePriceResponseDto> Execute(CalculatePriceRequestDto request)
        {
            Check(request);  // TODO: Rewrite with ArgumentNullException.ThrowIfNull(..)
            
            decimal pricePerHour = request.Tariff.PricePerHour;
            decimal totalHours = Math.Ceiling((decimal)request.RidePeriod.TotalHours);
            decimal price = pricePerHour * totalHours;
            decimal roundedPrice = Math.Round(price, CurrencyConstants.CURRENCY_PRECISION_DECIMALS, MidpointRounding.ToEven);

            return new CalculatePriceResponseDto()
            {
                Price = roundedPrice
            };
        }

        private void Check(CalculatePriceRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Tariff == null)
            {
                throw new ArgumentNullException(nameof(request.Tariff));
            }
        }
    }
}
