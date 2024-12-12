
using Domain.Entities.Core;

namespace Domain.Entities.Metadata
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public Guid BookId { get; set; }
        public string Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; } // Navigation properties public User User { get; set; } public Book Book { get; set; }

        // Nav
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
