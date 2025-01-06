
namespace Application.Dtos.BookDtos
{
    public class UpdateBookDto()
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
