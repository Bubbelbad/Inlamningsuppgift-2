
namespace Application.Dtos.AuthorDtos
{
    public class GetAuthorDto
    {
        public Guid AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Biography { get; set; }
    }
}
