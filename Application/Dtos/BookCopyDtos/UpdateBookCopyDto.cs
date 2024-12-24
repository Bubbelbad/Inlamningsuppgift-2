
namespace Application.Dtos.BookCopyDtos
{
    public class UpdateBookCopyDto
    {
        public Guid CopyId { get; set; }
        public Guid BookId { get; set; }
        public int BranchId { get; set; }
        public string? Status { get; set; }
    }
}
