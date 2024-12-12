namespace Application.Dtos
{
    public class AddBookDto(string title, Guid authorId, string description)
    {
        public string Title { get; set; } = title;
        public Guid AuthorId { get; set; } = authorId;
        public string Description { get; set; } = description;
    }
}
