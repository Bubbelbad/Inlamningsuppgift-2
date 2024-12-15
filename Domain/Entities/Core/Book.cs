using Domain.Entities.Locations;
using Domain.Entities.Metadata;
using Domain.Entities.Transactions;
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Core
{
    public class Book() : IEntity<Guid>
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cant be longer than 150 characters")]
        public string Title { get; set; }

        public DateTime? PublicationDate { get; set; }
        public Guid? AuthorId { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public int? PublisherId { get; set; }


        // Navigation properties
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookCopy> Copies { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Reservation> Reservations { get; set; }


        // Explicit implementation of IEntity<Guid>
        Guid IEntity<Guid>.Id
        {
            get => BookId;
            set => BookId = value;
        }
    }
}
