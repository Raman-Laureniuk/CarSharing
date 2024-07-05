namespace CarSharing.Domain.Mappers.CarUsage.Request
{
    using System;
    using CarSharing.Domain.Dto.CarUsage.Request;
    using CarSharing.Domain.Entities;

    internal static class StartUsageRequestMapper
    {
        public static CarUsage ToCarUsageEntity(this StartUsageRequestDto startUsageRequestDto)
        {
            if (startUsageRequestDto == null)
            {
                throw new ArgumentNullException(nameof(startUsageRequestDto));
            }

            return new CarUsage()
            {
                ClientId = startUsageRequestDto.ClientId,
                WalletId = startUsageRequestDto.WalletId,
                CarId = startUsageRequestDto.CarId,
                StartDateUtc = DateTime.UtcNow,
                EndDateUtc = null,
                TotalAmount = null,
                StatusId = 1  // TODO: Remove CarUsageStatus entity and use enum or string here.
            };
        }
    }
}
