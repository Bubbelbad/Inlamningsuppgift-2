using Domain.Entities.Base;
using Domain.Entities.Metadata;
using Domain.Entities.Transactions;
using Domain.Interfaces;


namespace Domain.Entities.Core
{
    public class User() : BaseUser
    {
        public string? Role { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
