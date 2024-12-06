namespace Application.Dtos
{
    public class AuthorDto(Guid id, string firstName, string lastName)
    {
        public Guid Id { get; set; } = id;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
    }
}
