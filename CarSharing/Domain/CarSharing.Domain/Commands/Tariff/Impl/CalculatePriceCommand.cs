namespace CarSharing.Domain.Commands.Tariff.Impl
{
    using System;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;

    internal class CalculatePriceCommand : ICalculatePriceCommand
    {
        public CalculatePriceResponseDto Execute(CalculatePriceRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Tariff == null)
            {
                throw new ArgumentNullException(nameof(request.Tariff));
            }

            decimal pricePerHour = request.Tariff.PricePerHour;
            int totalHours = (int)Math.Ceiling(request.RidePeriod.TotalHours);
            decimal price = pricePerHour * totalHours;

            return new CalculatePriceResponseDto()
            {
                Price = price
            };
        }
    }
}
