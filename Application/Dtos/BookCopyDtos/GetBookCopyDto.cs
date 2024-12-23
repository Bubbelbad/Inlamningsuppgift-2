
namespace Application.Dtos.BookCopyDtos
{
    public class GetBookCopyDto
    {
        public Guid CopyId { get; set; }
        public int BranchId { get; set; }
        public string? Status { get; set; }
    }
}
