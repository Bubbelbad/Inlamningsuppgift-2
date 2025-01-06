
namespace Application.Dtos.BookCopyDtos
{
    public class AddBookCopyDto
    {
        public Guid BookId { get; set; }
        public string Status { get; set; }
        public string FileFormat { get; set; }
        public long FileSize { get; set; }
        public string FilePath { get; set; }
    }
}
