namespace CarSharing.Domain.Dto.CarUsage.Response
{
    using System.Collections.Generic;

    public class GetUsageHistoryResponseDto
    {
        public List<CarUsageDto> CarUsages { get; set; }
    }
}
