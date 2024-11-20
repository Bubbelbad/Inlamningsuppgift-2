namespace Domain.Model
{
    public class Author (string firstName, string lastName)
    {
        public Guid Id { get; set; } = new Guid();
        public string? FirstName { get; set; } = firstName;
        public string? LastName { get; set; } = lastName; 
    }
}
