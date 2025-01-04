
namespace Application.Dtos.BorrowingDtos
{
    public class GetBorrowingDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public string UserId { get; set; }
        public Guid CopyId { get; set; }
    }
}
