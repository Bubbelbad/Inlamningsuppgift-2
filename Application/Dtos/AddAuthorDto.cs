namespace Application.Dtos
{
    public class AddAuthorDto(string firstName, string lastName)
    {
        public string? FirstName { get; set; } = firstName;
        public string? LastName { get; set; } = lastName;
    }
}