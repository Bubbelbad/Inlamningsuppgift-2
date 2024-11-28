namespace Domain.Model
{
    public class Author (Guid id, string firstName, string lastName)
    {
        public Guid Id { get; set; } = id; 
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName; 
    }
}
