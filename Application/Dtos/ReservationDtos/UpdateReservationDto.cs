namespace Application.Dtos.ReservationDtos
{
    public class UpdateReservationDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public Guid CopyId { get; set; }
        public string UserId { get; set; }
    }
}
