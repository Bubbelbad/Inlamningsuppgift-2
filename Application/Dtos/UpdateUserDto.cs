

namespace Application.Dtos
{
    public class UpdateUserDto(Guid id, string username, string password)
    {
        public Guid Id { get; set; } = id;
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;
    }
}
