using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UserDtos
{
    public class GetUserByUserNameDto
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}
