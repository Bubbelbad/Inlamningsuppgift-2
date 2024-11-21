namespace Application.Dtos
{
    public class AuthorDto(Guid id, string firstName, string lastName)
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
