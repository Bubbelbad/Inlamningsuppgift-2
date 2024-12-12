namespace Application.Dtos
{
    public class BookDto(Guid id, string title, Guid authorId, string description)
    {
        public Guid Id { get; set; } = id;
        public string Title { get; set; } = title;
        public Guid AuthorId { get; set; } = authorId;
        public string Description { get; set; } = description;
    }
}
