using Domain.Entities.Core;

namespace Domain.Entities.Metadata
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }
}
