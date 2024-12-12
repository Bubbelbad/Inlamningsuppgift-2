using Domain.Entities.Core;
using Domain.Entities.Locations;

namespace Domain.Entities.Transactions
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public string Id { get; set; }
        public Guid CopyId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public User User { get; set; }
        public BookCopy BookCopy { get; set; }
    }

}
