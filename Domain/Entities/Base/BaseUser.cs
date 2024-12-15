using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Base
{
    public class BaseUser : IdentityUser, IEntity<string>
    {
        string IEntity<string>.Id
        {
            get => Id;
            set => Id = value;
        }
    }
}
