namespace CarSharing.WebApi.Client.Messages.Car.Response
{
    using System.Collections.Generic;

    public class GetCarsResponseMessage
    {
        public List<CarMessage> Cars { get; set; }
    }
}
