using Domain.Entities.Metadata;
using Domain.Entities.Transactions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Core
{
    public class User() : IdentityUser, IEntity<string>
    {
        public string? Role { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
