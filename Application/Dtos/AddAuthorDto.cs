namespace Application.Dtos
{
    public class AddAuthorDto(string firstName, string lastName)
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}