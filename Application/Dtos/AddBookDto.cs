namespace Application.Dtos
{
    public class AddBookDto(string title, string author, string description)
    {
        public string? Title { get; set; } = title;
        public string? Author { get; set; } = author;
        public string? Description { get; set; } = description;
    }
}
