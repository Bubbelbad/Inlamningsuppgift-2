using Microsoft.AspNetCore.Identity;

namespace Domain.Model
{
    public class User : IdentityUser
    {
        public string? Role { get; set; }
    }
}
