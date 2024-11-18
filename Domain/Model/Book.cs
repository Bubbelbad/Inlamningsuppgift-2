namespace Domain
{
    public class Book(string title, string author, string description)
    {
        public Guid Id { get; set; } = new Guid();
        public string? Title { get; set; } = title;
        public string? Author { get; set; } = author;
        public string? Description { get; set; } = description;
    }
}
