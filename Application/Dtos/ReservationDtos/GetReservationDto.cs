
namespace Application.Dtos.ReservationDtos
{
    public class GetReservationDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime ReservationDate { get; set; }
        public Guid CopyId { get; set; }
        public string UserId { get; set; }
    }
}
