using Domain.Entities.Core;
using Domain.Interfaces;

namespace Domain.Entities.Metadata
{
    public class Publisher : IEntity<int>
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? ContactInfo { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }

        int IEntity<int>.Id
        {
            get => PublisherId;
            set => PublisherId = value;
        }
    }
}
