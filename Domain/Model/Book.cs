namespace Domain.Model
{
    public class Book (Guid id, string title, string author, string description)
    {
        public Guid Id { get; set; } = id; 
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;
        public string Description { get; set; } = description;
    }
}
