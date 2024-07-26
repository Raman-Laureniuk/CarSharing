namespace CarSharing.Domain.Dto.Client.Request
{
    public class GetClientsRequestDto
    {
        public string OrderBy { get; set; }
        public bool SortAscending { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
