using Domain.Entities.Core;

namespace Domain.Entities.Metadata
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? ContactInfo { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }

}
