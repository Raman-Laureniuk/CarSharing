namespace CarSharing.WebApi.Management.Messages.Car.Response
{
    using System.Collections.Generic;

    public class GetCarsResponseMessage
    {
        public List<CarMessage> Cars { get; set; }
    }
}
