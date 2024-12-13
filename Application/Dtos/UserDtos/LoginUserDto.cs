
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UserDtos
{
    public class LoginUserDto
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
