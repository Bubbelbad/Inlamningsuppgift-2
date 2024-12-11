

namespace Application.Dtos
{
    public class UpdateUserDto
    {
        public UpdateUserDto() { }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
