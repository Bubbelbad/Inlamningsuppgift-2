using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Book(Guid id, string title, string author, string description)
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; } = id;

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cant be longer than 150 characters")]
        public string Title { get; set; } = title;

        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author")]
        public string Author { get; set; } = author;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "Description cant be longer than 100 characters")]
        public string Description { get; set; } = description;
    }
}
