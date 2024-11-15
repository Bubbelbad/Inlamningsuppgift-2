namespace Domain
{
    public class Book(int id, string title, string author, string description)
    {
        public int Id { get; set; } = id;
        public string? Title { get; set; } = title;
        public string? Author { get; set; } = author;
        public string? Description { get; set; } = description;
    }
}
