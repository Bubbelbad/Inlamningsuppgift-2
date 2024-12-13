
namespace Application.Dtos.BookDtos
{
    public class UpdateBookDto()
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
    }
}
