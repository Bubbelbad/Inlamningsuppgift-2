namespace Application.Dtos
{
    public class BookDto (Guid id, string title, string author, string description)
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
