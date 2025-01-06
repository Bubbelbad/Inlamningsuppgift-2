
namespace Application.Dtos.BookDtos
{
    public class AddBookDto()
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public string ImageUrl { get; set; }
    }
}
