namespace Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }

        public Book(int id, string title, string author, string description)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
        }
    }
}
