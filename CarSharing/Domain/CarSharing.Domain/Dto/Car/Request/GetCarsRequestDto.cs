namespace CarSharing.Domain.Dto.Car.Request
{
    public class GetCarsRequestDto
    {
        public bool? IsAvailable { get; set; }
        public string OrderBy { get; set; }
        public bool SortAscending { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
