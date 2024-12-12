using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Core
{
    public class Author()
    {

        [Required(ErrorMessage = "{0} is required")]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "{0} cant be longer than 100 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "Name cant be longer than 100 characters")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }
}
