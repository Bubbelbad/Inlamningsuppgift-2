using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Author (Guid id, string firstName, string lastName)
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; } = id;

        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(100, ErrorMessage = "Name cant be longer than 100 characters")]
        public string FirstName { get; set; } = firstName;

        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(100, ErrorMessage = "Name cant be longer than 100 characters")]
        public string LastName { get; set; } = lastName; 
    }
}
