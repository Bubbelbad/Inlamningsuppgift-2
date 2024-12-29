using Domain.Entities.Core;
using Domain.Entities.Locations;

namespace Domain.Entities.Transactions
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime ReservationDate { get; set; }

        //FK
        public Guid CopyId { get; set; }
        public string UserId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public BookCopy BookCopy { get; set; }
    }
}
