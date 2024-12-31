using Domain.Entities.Core;
using Domain.Interfaces;

namespace Domain.Entities.Metadata
{
    public class Review : IEntity<int>
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public Guid BookId { get; set; }

        // FK
        public string UserId { get; set; }

        // Nav
        public User User { get; set; }
        public Book Book { get; set; }

        int IEntity<int>.Id
        {
            get => Id;
            set => Id = value;
        }
    }
}
