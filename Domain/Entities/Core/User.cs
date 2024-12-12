using Domain.Entities.Metadata;
using Domain.Entities.Transactions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Core
{
    public class User() : IdentityUser
    {
        public string? Role { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
