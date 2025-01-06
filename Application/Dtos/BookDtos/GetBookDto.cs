
namespace Application.Dtos.BookDtos
{
    public class GetBookDto()
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int Copies { get; set; }
        public string ImageUrl { get; set; }
        public Guid AuthorId { get; set; }
        public string PublisherId { get; set; }
    }
}
