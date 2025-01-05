using Domain.Entities.Base;
using Domain.Entities.Metadata;
using Domain.Entities.Transactions;
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities.Core
{
    public class User() : BaseUser
    {
        [Key]
        public override string Id { get; set; }
        public string? Role { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
