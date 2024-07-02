namespace CarSharing.Domain.Dto.Car.Response
{
    using System.Collections.Generic;

    public class GetCarsResponseDto
    {
        public List<CarDto> Cars { get; set; }
    }
}
