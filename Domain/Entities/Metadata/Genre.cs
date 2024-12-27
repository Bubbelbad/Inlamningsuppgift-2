using Domain.Entities.Core;
using Domain.Interfaces;

namespace Domain.Entities.Metadata
{
    public class Genre : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }

        int IEntity<int>.Id
        {
            get => Id;
            set => Id = value;
        }
    }
}
