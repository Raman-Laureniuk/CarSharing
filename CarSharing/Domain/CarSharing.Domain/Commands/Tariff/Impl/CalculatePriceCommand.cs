namespace CarSharing.Domain.Commands.Tariff.Impl
{
    using System;
    using CarSharing.Domain.Constants;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;

    internal class CalculatePriceCommand : ICalculatePriceCommand
    {
        public CalculatePriceResponseDto Execute(CalculatePriceRequestDto request)
        {
            Check(request);
            
            decimal pricePerHour = request.Tariff.PricePerHour;
            decimal totalHours = Math.Ceiling((decimal)request.RidePeriod.TotalHours);
            decimal price = pricePerHour * totalHours;
            decimal roundedPrice = Math.Round(price, CurrencyValues.CurrencyPrecisionDecimals, MidpointRounding.ToEven);

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
